#define TEST
using System;
using System.Windows.Forms;
using Binder.Tasks;
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
    { // TODO: Finish for TaskFormManager class!
        [TestMethod]
        public void TaskFormClass_FormState_FormLoadedProperly()
        {
            // Prepare:
            var tsk = new DataGridViewTask();
            var frmMgr = new Binder.UI.TaskFormManager(new TaskForm(tsk, false), tsk, false);
            // Execute:
            var result = frmMgr.LoadForm();
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TaskFormClass_DataManage_InputSavedProperly()
        {
            // Prepare:
            var tskStart = new DataGridViewTask()
            {
                Name = "Task",
                Date = DateTime.Now,
                IfToday = CheckState.Checked
            };
            var frmMgr = new Binder.UI.TaskFormManager(new TaskForm(tskStart, false), tskStart, false);
            frmMgr.LoadForm();
            frmMgr.OKButtonPressed();
            // Execute:
            //var result = 
            // Verify:
            Assert.AreEqual("Test", result);
        }

        [TestMethod]
        public void TaskFormClass_DialogResult_DialogReturnedOK()
        {
            // Prepare:
            var tsk = new DataGridViewTask();
            var frmMgr = new Binder.UI.TaskFormManager(new TaskForm(tsk, false), tsk, false);
            frmMgr.LoadForm();
            // Execute:
            //var result = 
            // Verify:
            //Assert.IsTrue(result);
        }

        [TestMethod]
        public void TaskFormClass_DialogResult_DialogReturnedCancel()
        {
            // Prepare:
            var tsk = new DataGridViewTask();
            var frmMgr = new Binder.UI.TaskFormManager(new TaskForm(tsk, false), tsk, false);
            frmMgr.LoadForm();
            // Execute:
            //var result = 
            // Verify:
            //Assert.IsTrue(result);
        }
    }
}
