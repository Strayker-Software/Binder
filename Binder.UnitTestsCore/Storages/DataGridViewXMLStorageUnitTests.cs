using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using Binder.Storages;
using Binder.UI;
using Binder.Tasks;

/* For copying to new methods:
 // Prepare:

 // Execute:

 // Verify:
 // Prepare and Execute:
 */

namespace Binder.UnitTests.Storages
{
    [TestClass]
    public class DataGridViewXMLStorageUnitTests
    {
        [TestMethod]
        public void Storage_SetAndGetDatabasePath_NewPathInObject()
        {
            // Prepare:
#pragma warning disable IDE0017 // Simplify object init,
            var strgm = new DataGridViewStorageManagerXML();
#pragma warning restore IDE0017 // Simplify object init,
            // Execute:
            strgm.StorageAccess = "databases\\Page1.xml";
            // Verify:
            Assert.AreEqual("databases\\Page1.xml", strgm.StorageAccess);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when given path is null.")]
        public void Storage_DataControl_StoragePathIsNotNull()
        {
            // Prepare:
#pragma warning disable IDE0017 // Simplify object init,
            var strgm = new DataGridViewStorageManagerXML();
#pragma warning restore IDE0017 // Simplify object init,
            // Execute:
            strgm.StorageAccess = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when given path is empty.")]
        public void Storage_DataControl_StoragePathIsNotEmpty()
        {
            // Prepare:
#pragma warning disable IDE0017 // Simplify object init,
            var strgm = new DataGridViewStorageManagerXML();
#pragma warning restore IDE0017 // Simplify object init,
            // Execute:
            strgm.StorageAccess = "";
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException), "Rise exception when given path directs to nothing.")]
        public void Storage_DataControl_DatabaseFileDoesntExist()
        {
            // Prepare:
#pragma warning disable IDE0017 // Simplify object init,
            var strgm = new DataGridViewStorageManagerXML();
#pragma warning restore IDE0017 // Simplify object init,
            // Execute:
            strgm.StorageAccess = "file.txt"; // Fake file,
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when table argument is null.")]
        public void Storage_DataControl_TableArgIsNotNull()
        {
            // Prepare and execute:
#pragma warning disable IDE0059 // Unneeded value assigment,
            var strgm = new DataGridViewStorageManagerXML
#pragma warning restore IDE0059 // Unneeded value assigment,
            {
                Tab = null
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when table don't have columns.")]
        public void Storage_DataControl_TableHaveNotColumnsSet()
        {
            // Prepare:
            var tab = new DataGridView();
            // Execute:
#pragma warning disable IDE0059 // Unneeded value assigment,
            var strgm = new DataGridViewStorageManagerXML
#pragma warning restore IDE0059 // Unneeded value assigment,
            {
                Tab = tab
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when task argument is null.")]
        public void Storage_DataControl_TaskArgIsNotNull()
        {
            // Prepare and execute:
#pragma warning disable IDE0059 // Unneeded value assigment,
            var strgm = new DataGridViewStorageManagerXML
#pragma warning restore IDE0059 // Unneeded value assigment,
            {
                Task = null
            };
        }

        [TestMethod]
        public void Storage_UpdateDatabase_NewDataInDatabase()
        {
            /*
                WARINING!
                This test has file system dependency
                and doesn't follow TDD rules.
            */

            // Prepare:
            var frm = new DataGridViewMain();
            var tabpage = frm.TabController.TabPages[0]; // Assuming only one page for the test,
            frm.SetDGV((DataGridView)tabpage.Controls[0]);
            var strgm = new DataGridViewStorageManagerXML
            {
                StorageAccess = "databases\\Page1.xml",
                Tab = (DataGridView)tabpage.Controls[0]
            };
            var row = new DataGridViewRow();
            row.CreateCells((DataGridView)strgm.Tab);
            row.SetValues("abc", DateTime.Now, CheckState.Checked);
            var tmp = (DataGridView)strgm.Tab;
            tmp.Rows.Add(row);
            // Execute:
            strgm.SaveToStorage();
            // Verify:
            Assert.AreEqual(row, tmp.Rows[0]);
        }

        [TestMethod]
        public void Storage_GetDataFromDatabase_NewDataLoadedFromBase()
        {
            /*
                WARINING!
                This test has file system dependency
                and doesn't follow TDD rules.
            */

            // Prepare:
            var frm = new DataGridViewMain();
            var tabpage = frm.TabController.TabPages[0]; // Assuming only one page for the test,
            frm.SetDGV((DataGridView)tabpage.Controls[0]);
            var tsk = new DataGridViewTask
            {
                Name = "abc",
                Date = DateTime.Now,
                IfToday = CheckState.Checked,
                Destination = (DataGridView)tabpage.Controls[0],
                TaskId = 0
            };
            var strgm = new DataGridViewStorageManagerXML
            {
                StorageAccess = "databases\\Page1.xml",
                Tab = (DataGridView)tabpage.Controls[0],
                Task = tsk
            };
            tsk.AddTask();
            strgm.SaveToStorage();
            tsk.DeleteTask();
            var tskFake = new DataGridViewTask();
            // Execute:
            strgm.LoadFromStorage();
            var tab = (DataGridView)tabpage.Controls[0];
            tab.Refresh();
            tskFake.Name = (string)tab.Rows[0].Cells[0].Value;
            tskFake.Date = (DateTime)tab.Rows[0].Cells[1].Value;
            tskFake.IfToday = (CheckState)tab.Rows[0].Cells[2].Value;
            tskFake.Destination = (DataGridView)tabpage.Controls[0];
            tskFake.TaskId = 0;
            // Verify:
            Assert.IsTrue(tsk.Equals(tskFake));
        }
    }
}
