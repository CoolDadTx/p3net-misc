#region Imports

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms; 

#endregion

namespace UpdateUserType
{
    public partial class MergeFilesDialog : Form
    {
        #region Construction

        public MergeFilesDialog ( )
        {
            InitializeComponent();
                  
            dgFiles.AutoGenerateColumns = false;
        }
        #endregion

        #region Public Members

        #region Attributes

        public bool AutoRefresh
        {
            get { return chkAutoRefresh.Checked; }
            set { chkAutoRefresh.Checked = value; }
        }

        public BindingList<FileData> MonitorFiles
        {
            get { return m_files; }
        }

        public TimeSpan RefreshInterval
        {
            get
            {
                int value;
                if (Int32.TryParse(txtRefreshInterval.Text, out value))
                    return new TimeSpan(0, 0, 0, 0, value);

                return new TimeSpan(0);
            }
            set
            {
                txtRefreshInterval.Text = ((int)value.TotalMilliseconds).ToString();
            }
        }
        #endregion

        #endregion

        #region Protected Members

        protected override void OnFormClosing ( FormClosingEventArgs e )
        {
            base.OnFormClosing(e);

            ValidateChildren();
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);
                        
            dgFiles.DataSource = m_files;

            UpdateUI();
        }
        #endregion

        #region Event Handlers

        private void OnAddFile ( object sender, LinkLabelLinkClickedEventArgs e )
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.AddExtension = true;
            dlg.AutoUpgradeEnabled = true;
            dlg.CheckFileExists = dlg.CheckPathExists = true;
            dlg.DefaultExt = ".txt";

            dlg.Filter = "Text Files|*.txt|All Files|*.*";            
            dlg.Multiselect = true;
            
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                foreach (string file in dlg.FileNames)
                {
                    FileData data = new FileData(file);
                    data.Monitor = true;

                    m_files.Add(data);
                };                
            };
        }

        private void OnCellDoubleClicked ( object sender, DataGridViewCellEventArgs e )
        {            
           //If it was the name or the path then open the file for editing
           if ((e.ColumnIndex == 0) || (e.ColumnIndex == 1))
           {
              if (m_files.Count >= e.RowIndex)
              {
                 FileData data = m_files[e.RowIndex];

                 try
                 {
                     this.Cursor = Cursors.WaitCursor;
                     Process.Start(data.FullPath);
                 } catch (Exception ex)
                 {
                     if (((ex is Win32Exception) && (((Win32Exception)ex).ErrorCode == -2147467259)) ||
                          (ex is FileNotFoundException))
                     {
                         if (MessageBox.Show("File does not exist.  Do you want to create it?", "Error",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Yes)
                         {
                             this.Cursor = Cursors.WaitCursor;

                             if (!Directory.Exists(data.Directory))
                                 Directory.CreateDirectory(data.Directory);

                             using (StreamWriter s = File.CreateText(data.FullPath))
                             {
                             };

                             Process.Start(data.FullPath);
                         };
                     } else
                         MessageBox.Show("Error opening file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 } finally
                 {
                     this.Cursor = Cursors.Default;
                 };
              };
           };
        }

        private void OnIntervalChanged ( object sender, EventArgs e )
        {
            Validate();
        }

        private void OnRefreshChanged ( object sender, EventArgs e )
        {
            UpdateUI();
        }

        private void OnValidatingInterval ( object sender, CancelEventArgs e )
        {
            if (txtRefreshInterval.Enabled)
            {
                int value;
                if (!Int32.TryParse(txtRefreshInterval.Text, out value))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtRefreshInterval, "Must enter an integral value.");
                } else
                    errorProvider1.SetError(txtRefreshInterval, null);
            } else
                errorProvider1.SetError(txtRefreshInterval, null);
        }
        #endregion

        #region Private Members

        private void UpdateUI ( )
        {
            txtRefreshInterval.Enabled = chkAutoRefresh.Checked;
            ValidateChildren();
        }

        private BindingList<FileData> m_files = new BindingList<FileData>();
        #endregion                                
    }
}
