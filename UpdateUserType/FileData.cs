#region Imports

using System;
using System.Collections.Generic;
using System.IO;
using System.Text; 
#endregion

namespace UpdateUserType
{
    public class FileData
    {
        #region Construction

        public FileData ( )
        {
        }

        public FileData ( string filePath )
        {
            Path = filePath;
            
            try
            {
                LastWriteTime = File.GetLastWriteTimeUtc(FullPath);
            } catch
            {
                LastWriteTime = DateTime.UtcNow;
            };
        }
        #endregion

        #region Public Members

        #region Attributes

        public string Directory
        {
            get { return System.IO.Path.GetDirectoryName(FullPath); }
        }

        public string FullPath
        {
            get { return m_fullPath ?? ""; }            
        }

        public DateTime LastWriteTime { get; set; }

        public bool Monitor { get; set; }

        public string Name
        {
            get { return System.IO.Path.GetFileName(Path); }
        }

        public string Path
        {
            get { return m_strPath ?? ""; }
            set 
            { 
                value = value ?? "";
                if (value.Length > 0)
                {
                    if (System.IO.Path.IsPathRooted(value))
                    {
                        m_strPath = m_fullPath = value;                        
                    } else
                    {                        
                        //Cheat here and switch to the assemblies directory temporarily so we can resolve
                        //relative paths
                        string currentDir = Environment.CurrentDirectory;
                        try
                        {
                            string asmPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                            Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(asmPath);

                            m_fullPath = System.IO.Path.GetFullPath(value);
                            m_strPath = value;
                        } finally
                        {
                            Environment.CurrentDirectory = currentDir;
                        };
                    };
                } else
                {
                    m_fullPath = m_strPath = "";
                };
            }
        }

        #endregion

        #endregion

        #region Private Members

        private string m_strPath;
        private string m_fullPath;
        #endregion
    }
}
