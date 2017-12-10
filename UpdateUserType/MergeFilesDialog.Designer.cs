namespace UpdateUserType
{
    partial class MergeFilesDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
           this.components = new System.ComponentModel.Container();
           this.label1 = new System.Windows.Forms.Label();
           this.button1 = new System.Windows.Forms.Button();
           this.button2 = new System.Windows.Forms.Button();
           this.dgFiles = new System.Windows.Forms.DataGridView();
           this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
           this.colPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
           this.colMonitor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
           this.lnkAddFiles = new System.Windows.Forms.LinkLabel();
           this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
           this.txtRefreshInterval = new System.Windows.Forms.TextBox();
           this.label2 = new System.Windows.Forms.Label();
           this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
           ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
           this.SuspendLayout();
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(13, 9);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(80, 13);
           this.label1.TabIndex = 4;
           this.label1.Text = "Files to monitor:";
           // 
           // button1
           // 
           this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
           this.button1.Location = new System.Drawing.Point(135, 309);
           this.button1.Name = "button1";
           this.button1.Size = new System.Drawing.Size(75, 23);
           this.button1.TabIndex = 5;
           this.button1.Text = "Merge";
           this.button1.UseVisualStyleBackColor = true;
           // 
           // button2
           // 
           this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.button2.CausesValidation = false;
           this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this.button2.Location = new System.Drawing.Point(216, 309);
           this.button2.Name = "button2";
           this.button2.Size = new System.Drawing.Size(75, 23);
           this.button2.TabIndex = 6;
           this.button2.Text = "Cancel";
           this.button2.UseVisualStyleBackColor = true;
           // 
           // dgFiles
           // 
           this.dgFiles.AllowUserToAddRows = false;
           this.dgFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.dgFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
           this.dgFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colPath,
            this.colMonitor});
           this.dgFiles.Location = new System.Drawing.Point(16, 26);
           this.dgFiles.Name = "dgFiles";
           this.dgFiles.Size = new System.Drawing.Size(383, 217);
           this.dgFiles.TabIndex = 7;
           this.dgFiles.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellDoubleClicked);
           // 
           // colName
           // 
           this.colName.DataPropertyName = "Name";
           this.colName.Frozen = true;
           this.colName.HeaderText = "Name";
           this.colName.Name = "colName";
           this.colName.ReadOnly = true;
           this.colName.Width = 125;
           // 
           // colPath
           // 
           this.colPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
           this.colPath.DataPropertyName = "FullPath";
           this.colPath.HeaderText = "Path";
           this.colPath.Name = "colPath";
           this.colPath.ReadOnly = true;
           // 
           // colMonitor
           // 
           this.colMonitor.DataPropertyName = "Monitor";
           this.colMonitor.HeaderText = "Monitor";
           this.colMonitor.Name = "colMonitor";
           this.colMonitor.Width = 50;
           // 
           // lnkAddFiles
           // 
           this.lnkAddFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.lnkAddFiles.AutoSize = true;
           this.lnkAddFiles.Location = new System.Drawing.Point(349, 255);
           this.lnkAddFiles.Name = "lnkAddFiles";
           this.lnkAddFiles.Size = new System.Drawing.Size(50, 13);
           this.lnkAddFiles.TabIndex = 8;
           this.lnkAddFiles.TabStop = true;
           this.lnkAddFiles.Text = "Add Files";
           this.lnkAddFiles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnAddFile);
           // 
           // chkAutoRefresh
           // 
           this.chkAutoRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
           this.chkAutoRefresh.AutoSize = true;
           this.chkAutoRefresh.Location = new System.Drawing.Point(16, 280);
           this.chkAutoRefresh.Name = "chkAutoRefresh";
           this.chkAutoRefresh.Size = new System.Drawing.Size(95, 17);
           this.chkAutoRefresh.TabIndex = 9;
           this.chkAutoRefresh.Text = "Rescan every:";
           this.chkAutoRefresh.UseVisualStyleBackColor = true;
           this.chkAutoRefresh.CheckedChanged += new System.EventHandler(this.OnRefreshChanged);
           // 
           // txtRefreshInterval
           // 
           this.txtRefreshInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
           this.txtRefreshInterval.Enabled = false;
           this.txtRefreshInterval.Location = new System.Drawing.Point(108, 278);
           this.txtRefreshInterval.Name = "txtRefreshInterval";
           this.txtRefreshInterval.Size = new System.Drawing.Size(49, 20);
           this.txtRefreshInterval.TabIndex = 10;
           this.txtRefreshInterval.TextChanged += new System.EventHandler(this.OnIntervalChanged);
           this.txtRefreshInterval.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidatingInterval);
           // 
           // label2
           // 
           this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(174, 281);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(63, 13);
           this.label2.TabIndex = 11;
           this.label2.Text = "milliseconds";
           // 
           // errorProvider1
           // 
           this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
           this.errorProvider1.ContainerControl = this;
           // 
           // MergeFilesDialog
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
           this.ClientSize = new System.Drawing.Size(411, 344);
           this.Controls.Add(this.label2);
           this.Controls.Add(this.txtRefreshInterval);
           this.Controls.Add(this.chkAutoRefresh);
           this.Controls.Add(this.lnkAddFiles);
           this.Controls.Add(this.dgFiles);
           this.Controls.Add(this.button2);
           this.Controls.Add(this.button1);
           this.Controls.Add(this.label1);
           this.Name = "MergeFilesDialog";
           this.Text = "Merge Files";
           ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgFiles;
        private System.Windows.Forms.LinkLabel lnkAddFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPath;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMonitor;
        private System.Windows.Forms.CheckBox chkAutoRefresh;
        private System.Windows.Forms.TextBox txtRefreshInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;

    }
}