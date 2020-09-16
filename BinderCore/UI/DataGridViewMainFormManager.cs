﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Binder.Properties;
using Binder.Storages;
using Binder.Tasks;

namespace Binder.UI
{
    /// <summary>
    /// IFormManager class to prepare Main form for user.
    /// </summary>
    public class DataGridViewMainFormManager : IFormManager
    { // TODO: Need unit tests of fields in this class!
        /// <summary>
        /// ITask object for loading and saving tasks.
        /// </summary>
        public ITask Task { get; set; }
        /// <summary>
        /// IStorage object for loading and saving data to storage area.
        /// </summary>
        public IStorage Strgm { get; set; }
        /// <summary>
        /// Main form object to operate on.
        /// </summary>
        public DataGridViewMain Form { get; set; }

        /// <summary>
        /// Constructor for DataGridViewMainFormManager class.
        /// </summary>
        /// <param name="form">Main form object to operate on.</param>
        public DataGridViewMainFormManager(DataGridViewMain form)
        {
            Task = new DataGridViewTask();
            Strgm = new DataGridViewStorageManagerXML();
            Form = form;
        }

        /// <summary>
        /// Save all tables to their storage areas and close all app's windows.
        /// </summary>
        /// <returns>Returns true if all operations are successful or false if at least one operation returned error.</returns>
        public bool CloseForm()
        {
            // Iterate through all tabs and save data:
            foreach (TabPage item in Form.TabController.TabPages)
            {
                try
                {
                    Strgm.StorageAccess = "databases\\" + item.Name + ".xml";
                    Strgm.DataDisplay = (DataGridView)item.Controls[0];
                    Strgm.SaveToStorage();
                }
                catch (Exception a)
                { // Exception handling - work ing progress on the better solution!
                    if (a.GetType() == typeof(FileNotFoundException))
                    {
                        MessageBox.Show("Error 2 for " + item.Name + ": Database file not found. Check if database file exists in app's path and try again.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else if (a.GetType() == typeof(ArgumentException))
                    {
                        MessageBox.Show("Error 1 for " + item.Name + ": Wrong database path was given. If you didn't change any database settings in code or in app, contact Strayker Software at https://straykersoftware.pl and send error code on support page!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("Error -1 for " + item.Name + ": There is unrecognised error in Binder! Contact Strayker Software at https://straykersoftware.pl for support!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Load data from storage areas and put them into correct tables.
        /// </summary>
        public bool LoadForm()
        {
            // Sort the tabs' names alphabetically:
            var list = new List<string>();
            foreach (string a in Settings.Default.Pages)
            {
                list.Add(a);
            }
            list.Sort();

            // Workover for Designer-made Page1 tab,
            Form.TabController.TabPages[0].Name = list[0];
            Form.TabController.TabPages[0].Text = list[0];
            list.RemoveAt(0);

            // For each tab, create table in app's window:
            foreach (string b in list)
            {
                var tab = new DataGridView();
                Form.SetDGV(tab);
                // Size values, I don't know why this values are working :/
                tab.Width = 184;
                tab.Height = 84;
                var pg = new TabPage
                {
                    Name = b,
                    Text = b
                };
                pg.BackColor = Color.White;
                pg.Controls.Add(tab);
                Form.TabController.TabPages.Add(pg);
            }

            // For each tab, check and load data:
            foreach (TabPage c in Form.TabController.TabPages)
            {
                try
                {
                    Strgm.StorageAccess = "databases\\" + c.Name + ".xml";
                    Strgm.DataDisplay = (DataGridView)c.Controls[0];
                    Strgm.LoadFromStorage();
                }
                catch (Exception a)
                { // TODO: Create custom Exception system!
                    if (a.GetType() == typeof(FileNotFoundException))
                    {
                        MessageBox.Show("Error 2: Database not found. Check if database exists in app's path and try again.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(2);
                    }
                    else if (a.GetType() == typeof(ArgumentException))
                    {
                        MessageBox.Show("Error 1: Wrong database path was given. If you didn't change any database settings in code or in app, contact Strayker Software at https://straykersoftware.pl and send error code on support page!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(1);
                    }
                    else
                    {
                        MessageBox.Show("Error -1: There is unrecognised error in Binder! Contact Strayker Software at https://straykersoftware.pl for support!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(-1);
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Method for adding new TabPage to TabController. Creates storage area too.
        /// </summary>
        public bool AddTabPage(string name)
        {
            // Check if TabPage with given name exists in controller:
            foreach (TabPage x in Form.TabController.TabPages)
            {
                if (name == x.Name)
                {
                    MessageBox.Show("Tab with this name already exist.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // No TabPage with this name, but there can be file named like this:
            if (File.Exists("databases\\" + name + ".xml"))
            {
                MessageBox.Show("Can't create the database file: database already exists!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Prepare DataGridView and TabPage objects and add them to UI:
            var tab = new DataGridView();
            Form.SetDGV(tab);
            // Size values, I don't know why this values are working :/
            tab.Width = 184;
            tab.Height = 84;
            var pg = new TabPage
            {
                Name = name,
                Text = name
            };
            pg.BackColor = Color.White;
            pg.Controls.Add(tab);
            Form.TabController.TabPages.Add(pg);

            // Create database file and update settings file:
            var stream = File.CreateText("databases\\" + name + ".xml");
            stream.Write("<?xml version='1.0' encoding='utf-8'?>\n<Storage>\n</Storage>");
            stream.Close();
            Settings.Default.Pages.Add(name);
            Settings.Default.Save();

            return true;
        }

        /// <summary>
        /// Method for deleting TabPage from TabController. Deletes storage area too.
        /// </summary>
        public bool DeleteTabPage()
        {
            // Check if Binder can delete the selected TabPage:
            if (Form.TabController.TabPages.Count > 1)
            {
                // Delete this TabPage:
                var tab = Form.TabController.SelectedTab;
                File.Delete("databases\\" + tab.Name + ".xml");
                Settings.Default.Pages.Remove(tab.Name);
                Form.TabController.TabPages.Remove(tab);
            }
            else
            {
                MessageBox.Show("You can't delete any more tabs.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method for saving data from active TabPage's table to storage area.
        /// </summary>
        public bool SaveTabPage()
        {
            try
            {
                // Just set needed data for storage manager and perform saving:
                Strgm.StorageAccess = "databases\\" + Form.TabController.SelectedTab.Name + ".xml";
                Strgm.DataDisplay = (DataGridView)Form.TabController.SelectedTab.Controls[0];
                Strgm.SaveToStorage();
                Form.statusStrip.Items[0].Text = "Data from " + Form.TabController.SelectedTab.Text + " saved!";
                Form.statusStrip.Items[0].Visible = true;
            }
            catch (Exception a)
            {
                if (a.GetType() == typeof(FileNotFoundException))
                {
                    MessageBox.Show("Error 2 for " + Form.TabController.SelectedTab.Name + ": Database file not found. Check if database file exists in app's path and try again.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (a.GetType() == typeof(ArgumentException))
                {
                    MessageBox.Show("Error 1 for " + Form.TabController.SelectedTab.Name + ": Wrong database path was given. If you didn't change any database settings in code or in app, contact Strayker Software at https://straykersoftware.pl and send error code on support page!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    MessageBox.Show("Error -1 for " + Form.TabController.SelectedTab.Name + ": There is unrecognised error in Binder! Contact Strayker Software at https://straykersoftware.pl for support!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Method for saving data from all TabPages' tables to storage area respectively.
        /// </summary>
        public bool SaveAllTabPages()
        {
            // For each tab, make the save operation:
            foreach (TabPage item in Form.TabController.TabPages)
            {
                try
                {
                    Strgm.StorageAccess = "databases\\" + item.Name + ".xml";
                    Strgm.DataDisplay = (DataGridView)item.Controls[0];
                    Strgm.SaveToStorage();
                }
                catch (Exception a)
                {
                    if (a.GetType() == typeof(FileNotFoundException))
                    {
                        MessageBox.Show("Error 2 for " + item.Name + ": Database file not found. Check if database file exists in app's path and try again.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else if (a.GetType() == typeof(ArgumentException))
                    {
                        MessageBox.Show("Error 1 for " + item.Name + ": Wrong database path was given. If you didn't change any database settings in code or in app, contact Strayker Software at https://straykersoftware.pl and send error code on support page!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("Error -1 for " + item.Name + ": There is unrecognised error in Binder! Contact Strayker Software at https://straykersoftware.pl for support!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            // Inform user:
            Form.statusStrip.Items[0].Text = "All data saved!";
            Form.statusStrip.Items[0].Visible = true;

            return true;
        }

        /// <summary>
        /// Method for asking user for data of task and adding it to table.
        /// </summary>
        public bool AddTask()
        {
            // Set selected TabPage with DataGridView for Task object and ask for data input:
            var tabpage = Form.TabController.SelectedTab;
            Task.Destination = (DataGridView)tabpage.Controls[0];
            Task.AddTask();
            Form.statusStrip.Items[0].Visible = false;

            return true;
        }

        /// <summary>
        /// Method for asking user for new data of existing task and changing it in the table.
        /// </summary>
        public bool EditTask()
        {
            // Save to var DataGridView object we want to operate on:
            var tab = (DataGridView)Form.TabController.SelectedTab.Controls[0];

            // Control the selection of data in DGV:
            if (tab.AreAllCellsSelected(false) == false && tab.SelectedRows.Count != 0)
            {
                // Get first row form selected rows collection, there should be only one element in the collection:
                var row = tab.SelectedRows[0];

                // Set data for Task object:
                Task.Name = (string)row.Cells[0].Value;
                Task.Date = (DateTime)row.Cells[1].Value;
                Task.IfToday = (CheckState)row.Cells[2].Value;

                // Get new data from user:
                var frm = new TaskForm(Task, true); // ITask argument, edit mode,
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    // Perform data update:
                    Task.Destination = tab;
                    Task.TaskId = row.Index;
                    Task.EditTask();
                    Form.statusStrip.Items[0].Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Please select correct row.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method for deleting task from table.
        /// </summary>
        public bool DeleteTask()
        {
            // Save to var DataGridView object we want to operate on:
            var tab = (DataGridView)Form.TabController.SelectedTab.Controls[0];
            // Get all selected rows (should be there only one element):
            var row = tab.SelectedRows;

            // Control the selection of data in DGV:
            if (tab.AreAllCellsSelected(false) == false && tab.SelectedRows.Count != 0)
            {
                // Perform remove operation:
                // TODO: Why not using ITask.DeleteTask() ?
                tab.Rows.Remove(row[0]);
                tab.Refresh();
                Form.statusStrip.Items[0].Visible = false;
            }
            else
            {
                MessageBox.Show("Please select correct row.", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method to rename the double-clicked TabPage.
        /// </summary>
        public bool RenameTabPage(string name)
        {
            // Save to var the selected TabPage,
            var tab = Form.TabController.SelectedTab;
            // Change name of database file:
            // TODO: Get this stuff to storage manager class!
            if (File.Exists("databases//" + tab.Name + ".xml")) File.Move("databases//" + tab.Name + ".xml", "databases//" + name + ".xml");
            else
            {
                MessageBox.Show("Can't find the database file to change the name!", "Binder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Update the settings file:
            Settings.Default.Pages.Remove(tab.Name);
            Settings.Default.Pages.Add(name);
            Settings.Default.Save();
            tab.Name = name;
            tab.Text = name;

            return true;
        }
    }
}
