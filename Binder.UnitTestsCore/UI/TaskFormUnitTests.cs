#define TEST
using System;
using System.Windows.Forms;
using Binder.Tasks;
using Binder.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/* For copying to new methods:
 // Prepare:

 // Execute:

 // Verify:
 // Prepare and Execute:
 */
namespace Binder.UnitTests.UI
{
    [TestClass]
    public class TaskFormUnitTests
    {
        [TestMethod]
        public void TaskFormClass_FieldTest_FormArgSetProperly()
        {
            // Prepare:
            var tsk = new DataGridViewTask();
            var frm = new TaskForm(tsk, false);
            // Execute:
            var frmMgr = new TaskFormManager(frm, tsk, false);
            // Verify:
            Assert.AreEqual(frm, frmMgr.Form);
        }

        [TestMethod]
        public void TaskFormClass_FieldTest_TaskArgSetProperly()
        {
            // Prepare:
            var tsk = new DataGridViewTask();
            var frm = new TaskForm(tsk, false);
            // Execute:
            var frmMgr = new TaskFormManager(frm, tsk, false);
            // Verify:
            Assert.AreEqual(tsk, frmMgr.Task);
        }

        [TestMethod]
        public void TaskFormClass_FormState_FormLoadedProperly()
        {
            // Prepare:
            var tsk = new DataGridViewTask();
            var frmMgr = new TaskFormManager(new TaskForm(tsk, false), tsk, false);
            // Execute:
            var result = frmMgr.LoadForm();
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException), "Rise excpetion because this method is not useful in this manager.")]
        public void TaskFormClass_FormState_FormCloseThrowsException()
        {
            // Prepare:
            var tsk = new DataGridViewTask();
            var frmMgr = new TaskFormManager(new TaskForm(tsk, false), tsk, false);
            // Execute:
#pragma warning disable IDE0059 // Useless value assigment,
            var result = frmMgr.CloseForm();
#pragma warning restore IDE0059 // Useless value assigment,
        }

        [TestMethod]
        public void TaskFormClass_DataManage_InputSavedProperly()
        {
            // Prepare:
            var time = DateTime.Now;
            // Changed task object:
            var tskStart = new DataGridViewTask()
            {
                Name = "Task",
                Date = time,
                IfToday = CheckState.Checked
            };
            // Unchanged task object:
            var tskTest = new DataGridViewTask()
            {
                Name = "Task",
                Date = time,
                IfToday = CheckState.Checked
            };
            var frmMgr = new TaskFormManager(new TaskForm(tskStart, false), tskStart, false);
            frmMgr.LoadForm();
            // Filling out data containers:
            frmMgr.Form.NameTextBox.Text = "Task";
            frmMgr.Form.DateTimePicker.Value = time;
            frmMgr.Form.IfTodayBox.Checked = true;
            // Execute:
            frmMgr.OKButtonPressed();
            // Verify:
            Assert.IsTrue(tskStart.Equals(tskTest));
        }

        [TestMethod]
        public void TaskFormClass_DialogResult_DialogReturnedOK()
        {
            // Prepare:
            var tsk = new DataGridViewTask();
            var frmMgr = new TaskFormManager(new TaskForm(tsk, false), tsk, false);
            frmMgr.LoadForm();
            frmMgr.Form.NameTextBox.Text = "Task";
            // Execute:
            var result = frmMgr.OKButtonPressed();
            // Verify:
            Assert.IsTrue(result);
        }
    }
}
