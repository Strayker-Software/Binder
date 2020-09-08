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
    public class TextMessageBoxUnitTests
    { // TODO: Finish for TextMessageBoxManager class!
        [TestMethod]
        public void TextMessageBoxClass_FormState_FormLoadedProperly()
        {
            // Prepare:
            var frmMgr = new Binder.UI.TextMessageBoxManager(new TextMessageBox(), "This is TextMessageBox");
            // Execute:
            var result = frmMgr.LoadForm();
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TextMessageBoxClass_DataManage_InputSavedProperly()
        {
            // Prepare:
            var frmMgr = new Binder.UI.TextMessageBoxManager(new TextMessageBox(), "This is TextMessageBox");
            frmMgr.LoadForm();
            frmMgr.Form.Input.Text = "Test";
            // Execute:
            var result = frmMgr.Form.Input.Text;
            // Verify:
            Assert.AreEqual("Test", result);
        }

        [TestMethod]
        public void TextMessageBoxClass_DialogResult_DialogReturnedOK()
        {
            // Prepare:
            var frmMgr = new Binder.UI.TextMessageBoxManager(new TextMessageBox(), "This is TextMessageBox");
            frmMgr.LoadForm();
            // Execute:
            //var result = 
            // Verify:
            //Assert.IsTrue(result);
        }

        [TestMethod]
        public void TextMessageBoxClass_DialogResult_DialogReturnedCancel()
        {
            // Prepare:
            var frmMgr = new Binder.UI.TextMessageBoxManager(new TextMessageBox(), "This is TextMessageBox");
            frmMgr.LoadForm();
            // Execute:
            //var result = 
            // Verify:
            //Assert.IsTrue(result);
        }
    }
}
