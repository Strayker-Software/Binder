using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Binder.Task;

namespace Binder.Storage
{
    /// <summary>
    /// Storage manager for DataGridView control in XML file.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class XMLStorageManager : IFileStorage
    {
        private string location;

        /// <summary>
        /// 
        /// </summary>
        public XMLStorageManager()
        {

        }

        /// <summary>
        /// Path to XML file for data.
        /// </summary>
        public string Location
        {
            get { return location; }
            set
            {
                if (value == null || value == "" || value.GetType() != typeof(string)) throw new ArgumentException("Value can't be null, have to be string but not empty.");
                else if (!File.Exists(Environment.CurrentDirectory + "\\" + value)) throw new FileNotFoundException("Given file doesn't exist.");

                location = value;
            }
        }

        /// <summary>
        /// Performs save operation, takes data from given Tab and save it to given storage file.
        /// </summary>
        public void SaveToStorage(ITask tsk)
        {
            // Create new XML storage file class,
            /*
            var doc = new XmlDocument();
            doc.LoadXml("<?xml version='1.0' encoding='utf-8'?>\n<Storage>\n</Storage>");
            var root = doc.DocumentElement;

            // For each row in table perform addition to XML file object and save to real file:
            foreach (DataGridViewRow item in dgv.Rows)
            {
                if (item.Cells[0].Value != null)
                {
                    
                }
            }
            doc.Save(Location);
            */
        }

        /// <summary>
        /// Performs load operation, takes data from given storage and sets them to given Tab.
        /// </summary>
        public IList<ICategory> LoadFromStorage()
        {
            // Reads all data from file,
            /*
            var reader = new StreamReader(Environment.CurrentDirectory + "\\" + StorageAccess);
            var data = reader.ReadToEnd();
            reader.Close();
            */

            // Pass data to XML class,
            /*
            var doc = new XmlDocument();
            doc.LoadXml(data);
            var root = doc.DocumentElement;
            */

            // Are there any tasks to load?
            /*
            if (root.ChildNodes.Count != 0)
            {
                // For each task in file, prepare data and add to destination:
                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    
                }
            }
            */
            return new List<ICategory>();
        }

        public void RenameFile(string newname)
        {

        }

        public bool CheckFileAccess()
        {
            return false;
        }
    }
}
