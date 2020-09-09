#define TEST
using System;
using System.Windows.Forms;
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
    public class TextMessageBoxUnitTests
    {
        [TestMethod]
        public void TextMessageBoxClass_FieldTest_MessageSetProperly()
        {
            // Prepare:
            var frmMgr = new TextMessageBoxManager(new TextMessageBox("This is TextMessageBox"), "This is TextMessageBox");
            // Execute:
            frmMgr.LoadForm();
            // Verify:
            Assert.AreEqual("This is TextMessageBox", frmMgr.Message);
        }

        [TestMethod]
        public void TextMessageBoxClass_FieldTest_InputSetProperly()
        {
            // Prepare:
            var frmMgr = new TextMessageBoxManager(new TextMessageBox("This is TextMessageBox"), "This is TextMessageBox");
            frmMgr.Form.Input.Text = "Test";
            frmMgr.LoadForm();
            // Execute:
            frmMgr.CloseForm();
            // Verify:
            Assert.AreEqual("Test", frmMgr.InputData);
        }

        [TestMethod]
        public void TextMessageBoxClass_FormState_FormLoadedProperly()
        {
            // Prepare:
            var frmMgr = new TextMessageBoxManager(new TextMessageBox("This is TextMessageBox"), "This is TextMessageBox");
            // Execute:
            var result = frmMgr.LoadForm();
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TextMessageBoxClass_FormState_FormClosedProperly()
        {
            // Prepare:
            var frm = new TextMessageBox("This is TextMessageBox");
            frm.Input.Text = "Test";
            var frmMgr = new TextMessageBoxManager(frm, "This is TextMessageBox");
            frmMgr.LoadForm();
            // Execute:
            frmMgr.CloseForm();
            // Verify:
            Assert.AreEqual("Test", frmMgr.InputData);
        }

        [TestMethod]
        public void TextMessageBoxClass_DialogResult_DialogReturnedOK()
        {
            // Prepare:
            var frmMgr = new TextMessageBoxManager(new TextMessageBox("This is TextMessageBox"), "This is TextMessageBox");
            frmMgr.LoadForm();
            // Execute:
            frmMgr.OKButtonPressed();
            // Verify:
            var result = frmMgr.Form.DialogResult;
            Assert.AreEqual(DialogResult.OK, result);
        }
    }
}
