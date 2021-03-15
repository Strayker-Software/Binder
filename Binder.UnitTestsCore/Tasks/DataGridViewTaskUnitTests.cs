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
