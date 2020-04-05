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
            var tsk = new Task
            {
                Name = "Task",
                Date = DateTime.Now,
                IfToday = CheckState.Checked
            };
            var frm = new Main();
            var rows = frm.Tab.Rows.Count;
            // Execute:
            tsk.AddTask(frm.Tab);
            // Verify:
            Assert.AreEqual(rows + 1, frm.Tab.Rows.Count);
        }

        [TestMethod]
        public void Task_DeleteTaskFromTable_OneLessTaskInTable()
        {
            // Prepare:
            var frm = new Main();
            var tsk = new Task();
            tsk.AddTask(frm.Tab);
            var rows = frm.Tab.Rows.Count;
            // Execute:
            tsk.DeleteTask(frm.Tab, 0);
            // Verify:
            Assert.AreEqual(rows - 1, frm.Tab.Rows.Count);
        }

        [TestMethod]
        public void Task_EditTaskInTable_NewNameOfTask()
        {
            // Prepare:
            var frm = new Main();
            var tsk = new Task();
            tsk.AddTask(frm.Tab);
            tsk.Name = "Name";
            // Execute:
            tsk.EditTask(frm.Tab, 0);
            // Verify:
            Assert.AreEqual("Name", frm.Tab.Rows[0].Cells[0].Value);
        }

        [TestMethod]
        public void Task_EditTaskInTable_NewDateOfTask()
        {
            // Prepare:
            var frm = new Main();
            var tsk = new Task();
            var time = DateTime.Now;
            tsk.AddTask(frm.Tab);
            tsk.Date = time;
            // Execute:
            tsk.EditTask(frm.Tab, 0);
            // Verify:
            Assert.AreEqual(time, frm.Tab.Rows[0].Cells[1].Value);
        }

        [TestMethod]
        public void Task_EditTaskInTable_NewIfTodayOfTask()
        {
            // Prepare:
            var frm = new Main();
            var tsk = new Task();
            var today = CheckState.Checked;
            tsk.AddTask(frm.Tab);
            tsk.IfToday = today;
            // Execute:
            tsk.EditTask(frm.Tab, 0);
            // Verify:
            Assert.AreEqual(today, frm.Tab.Rows[0].Cells[2].Value);
        }

        [TestMethod]
        public void Task_EditTaskInTable_AllNewData()
        {
            // Prepare:
            var frm = new Main();
            var tsk = new Task();

            var dat = DateTime.Now;
            var row = new DataGridViewRow(); // Fake row,
            row.CreateCells(frm.Tab);
            row.Cells[0].Value = "Name";
            row.Cells[1].Value = dat;
            row.Cells[2].Value = CheckState.Checked;
            frm.Tab.Rows.Add(row);

            tsk.AddTask(frm.Tab);
            tsk.Name = "Name";
            tsk.Date = dat;
            tsk.IfToday = CheckState.Checked;
            // Execute:
            tsk.EditTask(frm.Tab, 0);
            // Verify:
            Assert.AreEqual(row, frm.Tab.Rows[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when Name is null.")]
        public void Task_TaskClass_NewNameShouldNotBeNull()
        {
            // Prepare and Execute:
            var tsk = new Task
            {
                Name = null
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when Name is empty.")]
        public void Task_TaskClass_NewNameShouldNotBeEmpty()
        {
            // Prepare and Execute:
            var tsk = new Task
            {
                Name = ""
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when Date is minimal DateTime value.")]
        public void Task_TaskClass_NewDateMustSuitToDateTimeMinimalValue()
        {
            // Prepare and Execute:
            var tsk = new Task
            {
                Date = new DateTime()
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when IfToday is Indeterminate.")]
        public void Task_TaskClass_NewCheckStateShouldNotBeUndefined()
        {
            // Prepare and Execute:
            var tsk = new Task
            {
                IfToday = CheckState.Indeterminate
            };
        }

        [TestMethod]
        public void Task_TaskClass_GetCorrectNameOfTask()
        {
            // Prepare:
            var str = "Name";
            var tsk = new Task
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
            var tsk = new Task
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
            var tsk = new Task
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
