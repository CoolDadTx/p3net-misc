#region Imports

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
#endregion

namespace UpdateUserType
{
    internal class ConfigurationReaderWriter
    {
        #region Construction

        public ConfigurationReaderWriter ( )
        {
        }
        #endregion

        #region Public Members

        #region Attributes

        public bool AutoRefresh { get; set; }

        public List<FileData> MonitorFiles
        {
            get { return m_monitorFiles; }
        }

        public TimeSpan RefreshInterval { get; set; }
        #endregion

        #region Methods

        public void Load ( string filename )
        {
            if (File.Exists(filename))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filename);

                LoadFileMonitors(doc.DocumentElement);
            };
        }

        public void Save ( string filename )
        {
            XmlDocument doc = new XmlDocument();            
            XmlElement root = doc.CreateElement("updateUserType");
            doc.AppendChild(root);

            SaveFileMonitors(root);

            doc.Save(filename);
        }
        #endregion

        #endregion

        #region Private Members

        private bool GetAttributeAsBoolean ( XmlElement parent, string name, bool defaultValue )
        {
            string attrValue = parent.GetAttribute(name);
            attrValue = attrValue ?? "";

            bool value = defaultValue;
            Boolean.TryParse(attrValue, out value);

            return value;
        }

        private int GetAttributeAsInt32 ( XmlElement parent, string name, int defaultValue )
        {
            string attrValue = parent.GetAttribute(name);
            attrValue = attrValue ?? "";

            int value = defaultValue;
            Int32.TryParse(attrValue, out value);

            return value;
        }
        
        private void LoadFileMonitors ( XmlElement root )
        {
            //Attributes
            XmlElement monitorsRoot = root.SelectSingleNode("fileMonitors") as XmlElement;
            if (monitorsRoot == null)
                return;

            AutoRefresh = GetAttributeAsBoolean(monitorsRoot, "autoRefresh", true);
            RefreshInterval = new TimeSpan(0, 0, 0, 0, GetAttributeAsInt32(monitorsRoot, "refreshInterval", 0));                
            
            //Children
            XmlNodeList nodes = monitorsRoot.SelectNodes("fileMonitor");
            foreach (XmlNode node in nodes)
            {
                LoadFileMonitor(node);
            };
        }

        private void LoadFileMonitor ( XmlNode node )
        {
            XmlAttribute attr = node.Attributes["name"];
            string name = (attr != null) ? attr.Value : "";

            attr = node.Attributes["monitor"];
            bool monitor = false;

            try
            {
                monitor = (attr != null) ? Convert.ToBoolean(attr.Value) : false;
            } catch (FormatException)
            {
                monitor = (attr != null) ? Convert.ToInt32(attr.Value) == 1 : false;
            };

            if (name.Length > 0)
            {
                FileData data = new FileData(name);
                data.Monitor = monitor;

                m_monitorFiles.Add(data);
            };
        }

        private void SaveFileMonitors ( XmlElement root )
        {
            //Root
            XmlElement monitors = root.OwnerDocument.CreateElement("fileMonitors");
            root.AppendChild(monitors);

            //Attributes            
            monitors.SetAttribute("autoRefresh", AutoRefresh ? "true" : "false");
            monitors.SetAttribute("refreshInterval", RefreshInterval.TotalMilliseconds.ToString());

            //Children                       
            foreach (FileData file in m_monitorFiles)
            {
                SaveFileMonitor(monitors, file);
            };
        }

        private void SaveFileMonitor ( XmlElement parent, FileData file )
        {
            XmlElement monitor = parent.OwnerDocument.CreateElement("fileMonitor");

            monitor.SetAttribute("name", file.FullPath);
            monitor.SetAttribute("monitor", file.Monitor ? "true" : "false");

            parent.AppendChild(monitor);
        }

        private List<FileData> m_monitorFiles = new List<FileData>();
        #endregion
    }
}
