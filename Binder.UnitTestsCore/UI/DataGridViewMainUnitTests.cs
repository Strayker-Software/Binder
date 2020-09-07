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
    public class DataGridViewMainUnitTests
    {
        [TestMethod]
        public void MainClass_FormState_LoadedFormProperly()
        {
            // Prepare:
            var frmMgr = new Binder.UI.DataGridViewMainFormManager(new Binder.UI.DataGridViewMain());
            // Execute:
            var result = frmMgr.LoadForm();
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainClass_FormState_ClosedFormProperly()
        {
            // Prepare:
            var frmMgr = new Binder.UI.DataGridViewMainFormManager(new Binder.UI.DataGridViewMain());
            // Execute:
            var result = frmMgr.CloseForm();
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainClass_MenuBar_NewTabPageCreated()
        {
            // Prepare:
            var frmMgr = new Binder.UI.DataGridViewMainFormManager(new Binder.UI.DataGridViewMain());
            // Execute:
            var result = frmMgr.AddTabPage("Test");
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainClass_MenuBar_TabPageDeletedProperly()
        {
            // Prepare:
            var frmMgr = new Binder.UI.DataGridViewMainFormManager(new Binder.UI.DataGridViewMain());
            frmMgr.AddTabPage("Test");
            // Execute:
            var result = frmMgr.DeleteTabPage();
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainClass_MenuBar_SaveSuccesful()
        {
            // Prepare:
            var frmMgr = new Binder.UI.DataGridViewMainFormManager(new Binder.UI.DataGridViewMain());
            // Execute:
            var result = frmMgr.SaveTabPage();
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainClass_MenuBar_SaveAllSuccesful()
        {
            // Prepare:
            var frmMgr = new Binder.UI.DataGridViewMainFormManager(new Binder.UI.DataGridViewMain());
            frmMgr.AddTabPage("Test");
            frmMgr.AddTabPage("Test1");
            // Execute:
            var result = frmMgr.SaveAllTabPages();
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainClass_MenuBar_AddedNewTaskToGridView()
        {
            // Prepare:
            var frmMgr = new Binder.UI.DataGridViewMainFormManager(new Binder.UI.DataGridViewMain());
            // Execute:
            var result = frmMgr.AddTask();
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainClass_MenuBar_EditedTaskInGridView()
        {
            // Prepare:
            var frmMgr = new Binder.UI.DataGridViewMainFormManager(new Binder.UI.DataGridViewMain());
            var tsk = new DataGridViewTask
            {
                Name = "Test",
                Date = DateTime.Now,
                IfToday = CheckState.Checked
            };
            frmMgr.Task = tsk;
            frmMgr.AddTask();
            var tCtrl = (TabControl)frmMgr.Form.Controls[1]; // TabController,
            var dgv = (DataGridView)tCtrl.TabPages[0].Controls[0];
            dgv.Rows[0].Selected = true;
            // Execute:
            var result = frmMgr.EditTask();
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainClass_MenuBar_DeletedTaskFromGridView()
        {
            // Prepare:
            var frmMgr = new Binder.UI.DataGridViewMainFormManager(new Binder.UI.DataGridViewMain());
            frmMgr.AddTask();
            var tCtrl = (TabControl)frmMgr.Form.Controls[1]; // TabController,
            var dgv = (DataGridView)tCtrl.TabPages[0].Controls[0];
            dgv.Rows[0].Selected = true;
            // Execute:
            var result = frmMgr.DeleteTask();
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainClass_MenuBar_SettingsWindowShowedProperly()
        {
            Assert.IsTrue(true); // This test will be implemented, when settings window will be ready in app,
        }

        [TestMethod]
        public void MainClass_MenuBar_AboutAppWindowShowedProperly()
        {
            Assert.IsTrue(true); // This test will be implemented, when about app window's library will be added to the app,
        }

        [TestMethod]
        public void MainClass_TabPageControl_TabPageAndGridViewRenamedProperly()
        {
            // Prepare:
            var frmMgr = new Binder.UI.DataGridViewMainFormManager(new Binder.UI.DataGridViewMain());
            // Execute:
            frmMgr.RenameTabPage("NewTest");
            var tCtrl = (TabControl)frmMgr.Form.Controls[1]; // TabController,
            // Verify:
            Assert.AreEqual("NewTest", tCtrl.TabPages[0].Name);
        }
    }
}
