using System;
using System.Windows.Forms;
using Binder.Storages;
using Binder.Tasks;
using Binder.UI;
using Binder.UnitTests.Mock;
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
        public void MainClass_FieldTest_TaskSetProperly()
        {
            // Prepare:
            var tsk = new DataGridViewTask();
#pragma warning disable IDE0017 // Simplify object initialisation,
            var frmMgr = new DataGridViewMainFormManager(new DataGridViewMain());
#pragma warning restore IDE0017 // Simplify object initialisation,
            // Execute:
            frmMgr.Task = tsk;
            // Verify:
            Assert.AreEqual(tsk, frmMgr.Task);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when value of Task field is null.")]
        public void MainClass_FieldTest_TaskValueCantBeNull()
        {
            // Prepare and Execute:
#pragma warning disable IDE0059 // Useless value assigment,
            var frmMgr = new DataGridViewMainFormManager(new DataGridViewMain())
#pragma warning restore IDE0059 // Useless value assigment,
            {
                Task = null
            };
        }

        [TestMethod]
        public void MainClass_FieldTest_StorageManagerSetProperly()
        {
            // Prepare:
            var strgMgr = new DataGridViewStorageManagerXML();
#pragma warning disable IDE0017 // Simplify object initialisation,
            var frmMgr = new DataGridViewMainFormManager(new DataGridViewMain());
#pragma warning restore IDE0017 // Simplify object initialisation,
            // Execute:
            frmMgr.Strgm = strgMgr;
            // Verify:
            Assert.AreEqual(strgMgr, frmMgr.Strgm);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when value of Storage Manager field is null.")]
        public void MainClass_FieldTest_StorageManagerValueCantBeNull()
        {
            // Prepare and Execute:
#pragma warning disable IDE0059 // Useless value assigment,
            var frmMgr = new DataGridViewMainFormManager(new DataGridViewMain())
#pragma warning restore IDE0059 // Useless value assigment,
            {
                Strgm = null
            };
        }

        [TestMethod]
        public void MainClass_FieldTest_FormSetProperly()
        {
            // Prepare:
            var frm = new DataGridViewMain();
            // Execute:
#pragma warning disable IDE0017 // Simplify object initialisation,
            var frmMgr = new DataGridViewMainFormManager(frm);
#pragma warning restore IDE0017 // Simplify object initialisation,
            // Verify:
            Assert.AreEqual(frm, frmMgr.Form);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when value of Form field is null.")]
        public void MainClass_FieldTest_FormValueCantBeNull()
        {
            // Prepare and Execute:
#pragma warning disable IDE0059 // Useless value assigment,
            var frmMgr = new DataGridViewMainFormManager(null);
#pragma warning restore IDE0059 // Useless value assigment,
        }

        [TestMethod]
        public void MainClass_FormState_LoadedFormProperly()
        {
            // Prepare:
            var frmMgr = new DataGridViewMainFormManager(new DataGridViewMain());
            // Execute:
            var result = frmMgr.LoadForm();
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainClass_FormState_ClosedFormProperly()
        {
            // Prepare:
            var frmMgr = new DataGridViewMainFormManager(new DataGridViewMain());
            // Execute:
            var result = frmMgr.CloseForm();
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainClass_MenuBar_NewTabPageCreated()
        {
            // Prepare:
            var frmMgr = new DataGridViewMainFormManager(new DataGridViewMain());
            // Execute:
            var result = frmMgr.AddTabPage("Test");
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainClass_MenuBar_TabPageDeletedProperly()
        {
            // Prepare:
            var frmMgr = new DataGridViewMainFormManager(new DataGridViewMain());
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
            var frmMgr = new DataGridViewMainFormManager(new DataGridViewMain());
            // Execute:
            var result = frmMgr.SaveTabPage();
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainClass_MenuBar_SaveAllSuccesful()
        {
            // Prepare:
            var frmMgr = new DataGridViewMainFormManager(new DataGridViewMain());
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
            var frm = new DataGridViewMain();
            var tsk = new DataGridViewTask
            {
                Destination = (DataGridView)frm.TabController.TabPages[0].Controls[0],
                Name = "Test"
            };
            var frmMgr = new DataGridViewMainFormManager(frm)
            {
                Task = tsk
            };
            // Execute:
            var result = frmMgr.AddTask();
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainClass_MenuBar_EditedTaskInGridView()
        {
            // Prepare:
            var frm = new DataGridViewMain();
            var tCtrl = (TabControl)frm.Controls[1]; // TabController,
            var tsk = new DataGridViewTask
            {
                Name = "Test",
                Date = DateTime.Now,
                IfToday = CheckState.Checked,
                Destination = (DataGridView)tCtrl.TabPages[0].Controls[0]
            };
            var frmMgr = new DataGridViewMainFormManager(frm)
            {
                Task = tsk,
                DataDialog = new TaskFormMock(tsk, true) // Fake TaskForm-based object,
            };
            frmMgr.AddTask();
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
            var frm = new DataGridViewMain();
            var tsk = new DataGridViewTask
            {
                Destination = (DataGridView)frm.TabController.TabPages[0].Controls[0],
                Name = "Test"
            };
            var frmMgr = new DataGridViewMainFormManager(frm)
            {
                Task = tsk
            };
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
            var frmMgr = new DataGridViewMainFormManager(new DataGridViewMain());
            // Execute:
            frmMgr.RenameTabPage("NewTest");
            var tCtrl = (TabControl)frmMgr.Form.Controls[1]; // TabController,
            // Verify:
            Assert.AreEqual("NewTest", tCtrl.TabPages[0].Name);
        }
    }
}
