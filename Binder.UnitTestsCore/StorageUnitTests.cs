using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace Binder.UnitTests
{
    [TestClass]
    public class StorageUnitTests
    {
        [TestMethod]
        public void Storage_SetAndGetDatabasePath_NewPathInObject()
        {
            // Prepare:
#pragma warning disable IDE0017 // Simplify object init,
            var strgm = new StorageManagerXML();
#pragma warning restore IDE0017 // Simplify object init,
            // Execute:
            strgm.StorageAccess = "Data.xml";
            // Verify:
            Assert.AreEqual("Data.xml", strgm.StorageAccess);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when given path is null.")]
        public void Storage_DataControl_StoragePathIsNotNull()
        {
            // Prepare:
#pragma warning disable IDE0017 // Simplify object init,
            var strgm = new StorageManagerXML();
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
            var strgm = new StorageManagerXML();
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
            var strgm = new StorageManagerXML();
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
            var strgm = new StorageManagerXML
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
            var strgm = new StorageManagerXML
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
            var strgm = new StorageManagerXML
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
            frm.GridCreate();
            var strgm = new StorageManagerXML
            {
                StorageAccess = "Data.xml",
                Tab = frm.Tab1
            };
            var row = new DataGridViewRow();
            row.CreateCells(strgm.Tab);
            row.SetValues("abc", DateTime.Now, CheckState.Checked);
            strgm.Tab.Rows.Add(row);
            // Execute:
            strgm.SaveToStorage();
            // Verify:
            Assert.AreEqual(row, strgm.Tab.Rows[0]);
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
            frm.GridCreate();
            var strgm = new StorageManagerXML
            {
                StorageAccess = "Data.xml",
                Tab = frm.Tab1
            };
            var tsk1 = new Task
            {
                Name = "abc",
                Date = DateTime.Now,
                IfToday = CheckState.Checked
            };
            tsk1.AddTask(frm.Tab1);
            strgm.SaveToStorage();
            strgm.Tab.Rows.Clear();
            // Execute:
            strgm.LoadFromStorage();
            // Verify:
            var nrow = strgm.Tab.Rows[0];
            var tsk2 = new Task()
            {
                Name = (string)nrow.Cells[0].Value,
                Date = (DateTime)nrow.Cells[1].Value,
                IfToday = (CheckState)nrow.Cells[2].Value
            };
            Assert.IsTrue(tsk1.Equals(tsk2));
        }
    }
}
