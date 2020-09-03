using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace Binder.UnitTests
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
            var frm = new Main();
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
            var frm = new Main();
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
            strgm.Task = tskFake;
            // Execute:
            strgm.LoadFromStorage();
            // Verify:
            Assert.IsTrue(tsk.Equals(tskFake));
        }
    }
}
