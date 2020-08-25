using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace Binder.UnitTests
{
    [TestClass]
    public class TaskUnitTests
    {
        [TestMethod]
        public void Task_AddTaskToTable_NewTaskInTable()
        {
            // Prepare:
            var tsk = new DataGridViewTask
            {
                Name = "Task",
                Date = DateTime.Now,
                IfToday = CheckState.Checked
            };
            var frm = new Main();
            var tabpage = frm.TabController.TabPages[0]; // Assuming only one page for the test,
            var tab = (DataGridView)tabpage.Controls[0];
            frm.SetDGV(tab);
            var rows = tab.Rows.Count;
            // Execute:
            tsk.AddTask(tab);
            // Verify:
            Assert.AreEqual(rows + 1, tab.Rows.Count);
        }

        [TestMethod]
        public void Task_DeleteTaskFromTable_OneLessTaskInTable()
        {
            // Prepare:
            var frm = new Main();
            var tabpage = frm.TabController.TabPages[0]; // Assuming only one page for the test,
            var tab = (DataGridView)tabpage.Controls[0];
            frm.SetDGV(tab);
            var tsk = new DataGridViewTask();
            tsk.AddTask(tab);
            var rows = tab.Rows.Count;
            // Execute:
            tsk.DeleteTask(tab, 0);
            // Verify:
            Assert.AreEqual(rows - 1, tab.Rows.Count);
        }

        [TestMethod]
        public void Task_EditTaskInTable_NewNameOfTask()
        {
            // Prepare:
            var frm = new Main();
            var tabpage = frm.TabController.TabPages[0]; // Assuming only one page for the test,
            var tab = (DataGridView)tabpage.Controls[0];
            frm.SetDGV(tab);
            var tsk = new DataGridViewTask();
            tsk.AddTask(tab);
            tsk.Name = "Name";
            // Execute:
            tsk.EditTask(tab, 0);
            // Verify:
            Assert.AreEqual("Name", tab.Rows[0].Cells[0].Value);
        }

        [TestMethod]
        public void Task_EditTaskInTable_NewDateOfTask()
        {
            // Prepare:
            var frm = new Main();
            var tabpage = frm.TabController.TabPages[0]; // Assuming only one page for the test,
            var tab = (DataGridView)tabpage.Controls[0];
            frm.SetDGV(tab);
            var tsk = new DataGridViewTask();
            var time = DateTime.Now;
            tsk.AddTask(tab);
            tsk.Date = time;
            // Execute:
            tsk.EditTask(tab, 0);
            // Verify:
            Assert.AreEqual(time, tab.Rows[0].Cells[1].Value);
        }

        [TestMethod]
        public void Task_EditTaskInTable_NewIfTodayOfTask()
        {
            // Prepare:
            var frm = new Main();
            var tabpage = frm.TabController.TabPages[0]; // Assuming only one page for the test,
            var tab = (DataGridView)tabpage.Controls[0];
            frm.SetDGV(tab);
            var tsk = new DataGridViewTask();
            var today = CheckState.Checked;
            tsk.AddTask(tab);
            tsk.IfToday = today;
            // Execute:
            tsk.EditTask(tab, 0);
            // Verify:
            Assert.AreEqual(today, tab.Rows[0].Cells[2].Value);
        }

        [TestMethod]
        public void Task_EditTaskInTable_AllNewData()
        {
            // Prepare:
            var frm = new Main();
            var tabpage = frm.TabController.TabPages[0]; // Assuming only one page for the test,
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

            tsk.AddTask(tab);
            tsk.Name = "Name";
            tsk.Date = dat;
            tsk.IfToday = CheckState.Checked;
            // Execute:
            tsk.EditTask(tab, 0);
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
    }
}
