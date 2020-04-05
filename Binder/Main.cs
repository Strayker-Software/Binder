using System;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Text;

namespace Binder
{
    public partial class Main : Form
    {
        private readonly ITask Task;

        public Main()
        {
            InitializeComponent();
            Task = new Task();
        }

        /// <summary>
        /// Opens form to get data and adds data to grid.
        /// </summary>
        private void AddTask_Click(object sender, EventArgs e)
        {
            var frm = new TaskForm(Task, false); // ITask argument, no edit mode,
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.OK) Task.AddTask(Tab);
        }

        /// <summary>
        /// Deletes selected row from grid.
        /// </summary>
        private void DeleteTask_Click(object sender, EventArgs e)
        {
            if(Tab.AreAllCellsSelected(false) == false && Tab.SelectedRows.Count != 0)
            {
                var row = Tab.SelectedRows;
                Tab.Rows.Remove(row[0]);
                Tab.Refresh();
            }
            else
            {
                MessageBox.Show("Please select only one full row.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Opens form to edit the selected row.
        /// </summary>
        private void EditTask_Click(object sender, EventArgs e)
        {
            var row = Tab.SelectedRows;
            Task.Name = (string)row[0].Cells[0].Value;
            Task.Date = (DateTime)row[0].Cells[1].Value;
            Task.IfToday = (CheckState)row[0].Cells[2].Value;
            var frm = new TaskForm(Task, true); // ITask argument, edit mode,
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.OK) Task.EditTask(Tab, row[0].Index);
        }

        private void Main_Load(object sender, EventArgs e)
        { // TODO: Need optimalisation!
            var strgm = new StorageManager
            {
                StoragePath = "Data.xml"
            };
            var data = strgm.LoadFromStorage();
            var doc = new XmlDocument();
            doc.LoadXml(data);
            var root = doc.DocumentElement;
            if(root.ChildNodes.Count != 0)
            {
                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    var tskXml = root.ChildNodes.Item(i);
                    Task.Name = tskXml.Attributes.GetNamedItem("Name").Value;
                    Task.Date = Convert.ToDateTime(tskXml.Attributes.GetNamedItem("Date").Value);
                    if (tskXml.Attributes.GetNamedItem("Today").Value == "0") Task.IfToday = CheckState.Unchecked;
                    else Task.IfToday = CheckState.Checked;
                    Task.AddTask(Tab);
                }
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        { // TODO: Need optimalisation!
            var writer = File.OpenWrite("Data.xml");
            writer.Close(); // Cleans file,
            //var strgm = new StorageManager();
            var doc = new XmlDocument();
            doc.LoadXml("<?xml version='1.0' encoding='utf-8'?>\n<Storage>\n</Storage>");
            var root = doc.DocumentElement;
            foreach (DataGridViewRow item in Tab.Rows)
            {
                if(item.Cells[0].Value != null)
                {
                    var tskXml = doc.CreateElement("Task");
                    tskXml.SetAttribute("Name", (string)item.Cells[0].Value);
                    tskXml.SetAttribute("Date", Convert.ToString(item.Cells[1].Value));
                    if ((CheckState)item.Cells[2].Value == CheckState.Checked)
                        tskXml.SetAttribute("Today", "1");
                    else tskXml.SetAttribute("Today", "0");
                    root.AppendChild(tskXml);
                }
            }
            //string data = "a";
            doc.Save("Data.xml");
            //strgm.StoragePath = "Data.xml";
           // strgm.SaveToStorage(data);
        }
    }
}
