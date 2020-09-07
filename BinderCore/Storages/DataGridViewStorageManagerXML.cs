using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Binder.Tasks;

namespace Binder.Storages
{
    /// <summary>
    /// Storage manager for DataGridView control in XML file.
    /// </summary>
    public class DataGridViewStorageManagerXML : IStorage
    {
        private string storagePath;
        private DataGridView tab;
        private ITask task;

        /// <summary>
        /// 
        /// </summary>
        public DataGridViewStorageManagerXML()
        {
            Task = new DataGridViewTask();
        }

        /// <summary>
        /// Path to XML file for data.
        /// </summary>
        public object StorageAccess
        {
            get { return storagePath; }
            set
            {
                if (value == null || (string)value == "" || value.GetType() != typeof(string)) throw new ArgumentException("Value can't be null, have to be string but not empty.");
                else if (!File.Exists(Environment.CurrentDirectory + "\\" + value)) throw new FileNotFoundException("Given file doesn't exist.");

                storagePath = (string)value;
            }
        }

        /// <summary>
        /// DataGridView control for data presentation.
        /// </summary>
        public object Tab
        {
            get { return tab; }
            set
            {
                if (value == null) throw new ArgumentException("Value can't be null.");
                else if(value.GetType() != typeof(DataGridView)) throw new ArgumentException("This field requier value of type DataGridView.");

                var data = (DataGridView)value;
                if(data.Columns.Count < 3) throw new ArgumentException("DataGridView must contain at least three columns.");

                tab = (DataGridView)value;
            }
        }

        /// <summary>
        /// ITask object to operate on data in manager.
        /// </summary>
        public ITask Task
        {
            get { return task; }
            set
            {
                task = value ?? throw new ArgumentException("Value can't be null.");
            }
        }

        /// <summary>
        /// Performs load operation, takes data from given storage and sets them to given Tab.
        /// </summary>
        public void LoadFromStorage()
        {
            var reader = new StreamReader(Environment.CurrentDirectory + "\\" + StorageAccess);
            var data = reader.ReadToEnd();
            reader.Close();

            var doc = new XmlDocument();
            doc.LoadXml(data);
            var root = doc.DocumentElement;

            if (root.ChildNodes.Count != 0)
            {
                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    var tskXml = root.ChildNodes.Item(i);
                    Task.Name = tskXml.Attributes.GetNamedItem("Name").Value;
                    Task.Date = Convert.ToDateTime(tskXml.Attributes.GetNamedItem("Date").Value);
                    if (tskXml.Attributes.GetNamedItem("Today").Value == "0") Task.IfToday = CheckState.Unchecked;
                    else Task.IfToday = CheckState.Checked;
                    Task.Destination = Tab;
                    Task.AddTask();
                }
            }
        }

        /// <summary>
        /// Performs save operation, takes data from given Tab and save it to given storage file.
        /// </summary>
        public void SaveToStorage()
        {
            var doc = new XmlDocument();
            doc.LoadXml("<?xml version='1.0' encoding='utf-8'?>\n<Storage>\n</Storage>");
            var root = doc.DocumentElement;

            var dgv = (DataGridView)Tab;
            foreach (DataGridViewRow item in dgv.Rows)
            {
                if (item.Cells[0].Value != null)
                {
                    var tskXml = doc.CreateElement("Task");
                    tskXml.SetAttribute("Name", (string)item.Cells[0].Value);
                    tskXml.SetAttribute("Date", Convert.ToString(item.Cells[1].Value));
                    if ((CheckState)item.Cells[2].Value == CheckState.Checked) tskXml.SetAttribute("Today", "1");
                    else tskXml.SetAttribute("Today", "0");
                    root.AppendChild(tskXml);
                }
            }
            doc.Save((string)StorageAccess);
        }
    }
}
