using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using Binder.Tasks;
using Binder.UI;

/* For copying to new methods:
 // Prepare:

 // Execute:

 // Verify:
 // Prepare and Execute:
 */

namespace Binder.UnitTests.Tasks
{
    [TestClass]
    public class DataGridViewTaskUnitTests
    {
        [TestMethod]
        public void Task_AddTaskToTable_NewTaskInTable()
        {
            // Prepare:
            var frm = new DataGridViewMain();
            var tabpage = frm.TabController.TabPages[0]; // Assuming only one page with one table for the test,
            frm.SetDGV((DataGridView)tabpage.Controls[0]);
            var tsk = new DataGridViewTask
            {
                Name = "Task",
                Date = DateTime.Now,
                IfToday = CheckState.Checked,
                Destination = (DataGridView)tabpage.Controls[0]
            }; // No need in setting TaskID,
            var tab = (DataGridView)tsk.Destination;
            var rows = tab.Rows.Count;
            // Execute:
            tsk.AddTask();
            // Verify:
            Assert.AreEqual(2, rows + 1);
        }

        [TestMethod]
        public void Task_DeleteTaskFromTable_OneLessTaskInTable()
        {
            // Prepare:
            var frm = new DataGridViewMain();
            var tabpage = frm.TabController.TabPages[0]; // Assuming only one page with one table for the test,
            var tab = (DataGridView)tabpage.Controls[0];
            frm.SetDGV(tab);
            var tsk = new DataGridViewTask
            {
                Destination = tab,
                TaskId = 0
            };
            tsk.AddTask();
            var rows = tab.Rows.Count;
            // Execute:
            tsk.DeleteTask();
            // Verify:
            Assert.AreEqual(rows - 1, tab.Rows.Count);
        }

        [TestMethod]
        public void Task_EditTaskInTable_NewNameOfTask()
        {
            // Prepare:
            var frm = new DataGridViewMain();
            var tabpage = frm.TabController.TabPages[0]; // Assuming only one page with one table for the test,
            var tab = (DataGridView)tabpage.Controls[0];
            frm.SetDGV(tab);
            var tsk = new DataGridViewTask
            {
                Destination = tab,
                Name = "Name",
                TaskId = 0
            };
            tsk.AddTask();
            // Execute:
            tsk.EditTask();
            // Verify:
            Assert.AreEqual("Name", tab.Rows[0].Cells[0].Value);
        }

        [TestMethod]
        public void Task_EditTaskInTable_NewDateOfTask()
        {
            // Prepare:
            var frm = new DataGridViewMain();
            var tabpage = frm.TabController.TabPages[0]; // Assuming only one page with one table for the test,
            var tab = (DataGridView)tabpage.Controls[0];
            frm.SetDGV(tab);
            var tsk = new DataGridViewTask();
            var time = DateTime.Now;
            tsk.Destination = tab;
            tsk.AddTask();
            tsk.Date = time;
            tsk.TaskId = 0;
            // Execute:
            tsk.EditTask();
            // Verify:
            Assert.AreEqual(time, tab.Rows[0].Cells[1].Value);
        }

        [TestMethod]
        public void Task_EditTaskInTable_NewIfTodayOfTask()
        {
            // Prepare:
            var frm = new DataGridViewMain();
            var tabpage = frm.TabController.TabPages[0]; // Assuming only one page with one table for the test,
            var tab = (DataGridView)tabpage.Controls[0];
            frm.SetDGV(tab);
            var tsk = new DataGridViewTask();
            var today = CheckState.Checked;
            tsk.Destination = tab;
            tsk.AddTask();
            tsk.IfToday = today;
            tsk.TaskId = 0;
            // Execute:
            tsk.EditTask();
            // Verify:
            Assert.AreEqual(today, tab.Rows[0].Cells[2].Value);
        }

        [TestMethod]
        public void Task_EditTaskInTable_AllNewData()
        {
            // Prepare:
            var frm = new DataGridViewMain();
            var tabpage = frm.TabController.TabPages[0]; // Assuming only one page with one table for the test,
            var tab = (DataGridView)tabpage.Controls[0];
            frm.SetDGV(tab);
            var tsk = new DataGridViewTask();

            var dat = DateTime.Now;
            var row = new DataGridViewRow(); // Fake row,
            row.CreateCells(tab);
            row.Cells[0].Value = "Name";
            row.Cells[1].Value = dat;
            row.Cells[2].Value = CheckState.Checked;
            tab.Rows.Add(row);

            tsk.Destination = tab;
            tsk.AddTask();
            tsk.Name = "Name";
            tsk.Date = dat;
            tsk.IfToday = CheckState.Checked;
            tsk.TaskId = 0;
            // Execute:
            tsk.EditTask();
            // Verify:
            Assert.AreEqual(row, tab.Rows[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when Name is null.")]
        public void Task_TaskClass_NewNameShouldNotBeNull()
        {
            // Prepare and Execute:
#pragma warning disable IDE0059 // Not needed value assigment,
            var tsk = new DataGridViewTask
#pragma warning restore IDE0059 // Not needed value assigment,
            {
                Name = null
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when Name is empty.")]
        public void Task_TaskClass_NewNameShouldNotBeEmpty()
        {
            // Prepare and Execute:
#pragma warning disable IDE0059 // Not needed value assigment,
            var tsk = new DataGridViewTask
#pragma warning restore IDE0059 // Not needed value assigment,
            {
                Name = ""
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when Date is minimal DateTime value.")]
        public void Task_TaskClass_NewDateMustSuitToDateTimeMinimalValue()
        {
            // Prepare and Execute:
#pragma warning disable IDE0059 // Not needed value assigment,
            var tsk = new DataGridViewTask
#pragma warning restore IDE0059 // Not needed value assigment,
            {
                Date = new DateTime()
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when IfToday is Indeterminate.")]
        public void Task_TaskClass_NewCheckStateShouldNotBeUndefined()
        {
            // Prepare and Execute:
#pragma warning disable IDE0059 // Not needed value assigment,
            var tsk = new DataGridViewTask
#pragma warning restore IDE0059 // Not needed value assigment,
            {
                IfToday = CheckState.Indeterminate
            };
        }

        [TestMethod]
        public void Task_TaskClass_GetCorrectNameOfTask()
        {
            // Prepare:
            var str = "Name";
            var tsk = new DataGridViewTask
            {
                Name = str
            };
            // Execute:
            var result = tsk.Name;
            // Verify:
            Assert.AreEqual(str, result);
        }

        [TestMethod]
        public void Task_TaskClass_GetCorrectDateOfTask()
        {
            // Prepare:
            var dat = DateTime.Now;
            var tsk = new DataGridViewTask
            {
                Date = dat
            };
            // Execute:
            var result = tsk.Date;
            // Verify:
            Assert.AreEqual(dat, result);
        }

        [TestMethod]
        public void Task_TaskClass_GetCorrectTodayStatementOfTask()
        {
            // Prepare:
            var today = CheckState.Checked;
            var tsk = new DataGridViewTask
            {
                IfToday = today
            };
            // Execute:
            var result = tsk.IfToday;
            // Verify:
            Assert.AreEqual(today, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when given object is not DataGridView object.")]
        public void Task_TaskClass_NewDestinationNotDataGridViewObject()
        {
            // Prepare and Execute:
            var x = 10;
#pragma warning disable IDE0059 // Unneeded value assigment
            var task = new DataGridViewTask
#pragma warning restore IDE0059 // Unneeded value assigment,
            {
                Destination = x
            };
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Rise exception when given data is null.")]
        public void Task_TaskClass_NewDestinationMustNotBeNull()
        {
            // Prepare and Execute:
#pragma warning disable IDE0059 // Unneeded value assigment,
            var task = new DataGridViewTask
#pragma warning restore IDE0059 // Unneeded value assigment,
            {
                Destination = null
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when given DataGridView object doesn't have three columns.")]
        public void Task_TaskClass_NewDestinationTableMustHaveThreeColumns()
        {
            // Prepare:
            var task = new DataGridViewTask();
            var tab = new DataGridView();
            tab.Columns.Add("Name", "Name");
            tab.Columns.Add("Deadline", "Deadline");
            // Execute:
            task.Destination = tab;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Rise exception when task ID is lower than zero.")]
        public void Task_TaskClass_TaskIDMustBeAtLeastOne()
        {
            // Prepare and Execute:
#pragma warning disable IDE0059 // Unneeded value assigment,
            var tsk = new DataGridViewTask
#pragma warning restore IDE0059 // Unneeded value assigment,
            {
                TaskId = -1
            };
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Rise exception when task ID points to null task.")]
        public void Task_TaskClass_TaskIDMustBeInTheDestination()
        {
            // Prepare and Execute:
            var frm = new DataGridViewMain();
            var tab = (DataGridView)frm.TabController.TabPages[0].Controls[0];
#pragma warning disable IDE0059 // Unneeded value assigment,
            var tsk = new DataGridViewTask
#pragma warning restore IDE0059 // Unneeded value assigment,
            {
                Destination = tab,
                TaskId = 2
            };
        }

        [TestMethod]
        public void Task_TaskClass_EqualityMethodReturnsTrue()
        {
            // Prepare:
            var tsk = new DataGridViewTask
            {
                Name = "Name"
            };
            var tsk1 = new DataGridViewTask
            {
                Name = "Name"
            };
            // Execute:
            var result = tsk.Equals(tsk1);
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Task_TaskClass_EqualityMethodReturnsFalse()
        {
            // Prepare:
            var tsk = new DataGridViewTask
            {
                Name = "Name"
            };
            var tsk1 = new DataGridViewTask
            {
                Name = "OK"
            };
            // Execute:
            var result = tsk.Equals(tsk1);
            // Verify:
            Assert.IsFalse(result);
        }
    }
}
