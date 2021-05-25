using System;
using System.Windows.Forms;
using Binder.Storage;
using Binder.Task;
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
    [Ignore]
    [TestClass]
    public class StandardTaskFormUnitTests
    {
        [TestMethod]
        public void TaskFormClass_FieldTest_FormArgSetProperly()
        {
            /*
            // Prepare:
            var tsk = new DataGridViewTask();
            var frm = new TaskForm(tsk, false);
            // Execute:
            var frmMgr = new TaskFormManager(frm, tsk, false);
            // Verify:
            Assert.AreEqual(frm, frmMgr.Form);
            */
        }

        [TestMethod]
        public void TaskFormClass_FieldTest_DialogArgSetProperly()
        {
            /*
            // Prepare:
            var tsk = new DataGridViewTask();
            var frm = new TaskForm(tsk, false);
#pragma warning disable IDE0017 // Simplify object initialisation,
            var frmMgr = new TaskFormManager(frm, tsk, false);
#pragma warning restore IDE0017 // Simplify object initialisation,
            // Execute:
            frmMgr.DataDialog = frm;
            // Verify:
            Assert.AreEqual(frm, frmMgr.DataDialog);
            */
        }

        [TestMethod]
        public void TaskFormClass_FormState_FormLoadedProperly()
        {
            /*
            // Prepare:
            var tsk = new DataGridViewTask();
            var frmMgr = new TaskFormManager(new TaskForm(tsk, false), tsk, false);
            // Execute:
            var result = frmMgr.LoadForm();
            // Verify:
            Assert.IsTrue(result);
            */
        }
    }
}
