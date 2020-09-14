using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Binder.Properties;
using Binder.Tasks;

namespace Binder.UI
{
    public partial class DataGridViewMain : Form
    {
        private readonly IFormManager formManager;

        /// <summary>
        /// Main class constructor.
        /// </summary>
        public DataGridViewMain()
        {
            InitializeComponent();
            SetDGV(DataTab);
            formManager = new DataGridViewMainFormManager(this);
#if DEBUG
            DevLabel.Text = "Binder v" + Application.ProductVersion + " - Strayker Software Development Build - Use only for dev operations";
            DevLabel.Visible = true;
            Settings.Default.Reset();
            foreach (string x in Directory.GetFiles("databases\\"))
            {
                File.Delete(x);
            }
            var stream = File.CreateText("databases\\Page1.xml");
            stream.Write("<?xml version='1.0' encoding='utf-8'?>\n<Storage>\n</Storage>");
            stream.Close();
#endif
        }

        /// <summary>
        /// Set default settings for DataGridView. Workover for .NET Core Designer bugs.
        /// </summary>
        /// <param name="tab">DataGridView object to add columns to.</param>
        public void SetDGV(DataGridView tab)
        {
            // Set DataGridView properties:
            tab.ReadOnly = true;
            tab.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tab.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tab.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tab.EditMode = DataGridViewEditMode.EditProgrammatically;
            tab.Location = new Point(7, 7);
            tab.Margin = new Padding(4, 3, 4, 3);
            tab.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // TaskName
            TaskName = new DataGridViewTextBoxColumn
            {
                HeaderText = "Task Name",
                Name = "TaskName"
            };
            // Deadline
            Deadline = new DataGridViewTextBoxColumn
            {
                HeaderText = "Deadline",
                Name = "Deadline"
            };
            // Today
            Today = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Today?",
                Name = "Today"
            };

            tab.Columns.AddRange(TaskName, Deadline, Today);
        }

        /// <summary>
        /// Exectued on main form's start.
        /// </summary>
        private void Main_Load(object sender, EventArgs e)
        {
            formManager.LoadForm();
        }

        /// <summary>
        /// Executed on main form's closing.
        /// </summary>
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ask if user really want to exit:
            var dialog = MessageBox.Show("Are you sure you want to exit Binder? All task tables will be saved.", "Binder", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialog == DialogResult.Yes)
            {
                if (formManager.CloseForm() == false) e.Cancel = true;
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Creates new tab with separate table.
        /// </summary>
        private void NewTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new TextMessageBox("Please write name of new data tab here:");
            dialog.ShowDialog();

            if (dialog.DialogResult == DialogResult.OK)
            {
                if (dialog.Input.Text != "" && dialog.Input.Text != null)
                {
                    var mgr = (DataGridViewMainFormManager)formManager;
                    mgr.AddTabPage(dialog.Input.Text);
                }
                else
                {
                    MessageBox.Show("You have to write name for new tab!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Deletes active tab and data.
        /// </summary>
        private void DeleteTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mgr = (DataGridViewMainFormManager)formManager;
            mgr.DeleteTabPage();
        }

        /// <summary>
        /// Save current tab data to database.
        /// </summary>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mgr = (DataGridViewMainFormManager)formManager;
            mgr.SaveTabPage();
        }

        /// <summary>
        /// Saves all tabs to databases respectively.
        /// </summary>
        private void SaveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mgr = (DataGridViewMainFormManager)formManager;
            mgr.SaveAllTabPages();
        }

        /// <summary>
        /// Exits the program.
        /// </summary>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Opens form to get data and adds data to grid.
        /// </summary>
        private void AddTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Change logic to fit form manager!
            var tsk = new DataGridViewTask();
            var frm = new TaskForm(tsk, false); // ITask argument, no edit mode,
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                var mgr = (DataGridViewMainFormManager)formManager;
                mgr.Task = tsk;
                mgr.AddTask();
            }
        }

        /// <summary>
        /// Opens form to edit the selected row.
        /// </summary>
        private void EditTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mgr = (DataGridViewMainFormManager)formManager;
            mgr.EditTask();
        }

        /// <summary>
        /// Deletes selected row from grid.
        /// </summary>
        private void DeleteTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mgr = (DataGridViewMainFormManager)formManager;
            mgr.DeleteTask();
        }

        /// <summary>
        /// Shows up settings screen.
        /// </summary>
        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        { // TODO: Add settings window!
            MessageBox.Show("This window will be added in next versions of Binder! Work in progress.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows about app window.
        /// </summary>
        private void AboutAppToolStripMenuItem_Click(object sender, EventArgs e)
        { // TODO: Add library with this window!
            MessageBox.Show("This window will be added in next versions of Binder! Work in progress.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        /// <summary>
        /// Handles name change of existing tab.
        /// </summary>
        private void TabController_DoubleClick(object sender, EventArgs e)
        {
            var dialog = new TextMessageBox("Please write new name for this tab:");
            dialog.ShowDialog();

            if (dialog.DialogResult == DialogResult.OK)
            {
                if (dialog.Input.Text != "" && dialog.Input.Text != null)
                {
                    var mgr = (DataGridViewMainFormManager)formManager;
                    mgr.RenameTabPage(dialog.Input.Text);
                }
            }
        }
    }
}
