using System;
using System.Collections.Generic;
using Binder.Controllers;
using Binder.Data;
using Binder.Data.Storage;
using Binder.Task;
using Binder.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

/* For copying to new methods:
 // Prepare:

 // Execute:

 // Verify:

 // Prepare and Execute:

*/

namespace Binder.UnitTests.Controllers
{
    [TestClass]
    public class StandardControllerUnitTests
    {
        [TestMethod]
        public void Controller_Fields_CategoriesFieldSetProperly()
        {
            // Prepare and Execute:
            var obj = new StandardController(new Mock<IForm>().Object, new Mock<IStorage>().Object, new Mock<IDataConverter>().Object);
            // Verify:
            Assert.IsTrue(obj.Categories != null);
        }

        [TestMethod]
        public void Controller_Fields_StorageFieldSetProperly()
        {
            // Prepare and Execute:
            var obj = new StandardController(new Mock<IForm>().Object, new Mock<IStorage>().Object, new Mock<IDataConverter>().Object);
            // Verify:
            Assert.IsTrue(obj.ActiveStorage != null);
        }

        [TestMethod]
        public void Controller_Fields_FormFieldSetProperly()
        {
            // Prepare and Execute:
            var obj = new StandardController(new Mock<IForm>().Object, new Mock<IStorage>().Object, new Mock<IDataConverter>().Object);
            // Verify:
            Assert.IsTrue(obj.ActiveForm != null);
        }

        [TestMethod]
        public void Controller_Fields_DataInputDialogSetProperly()
        {
            // Prepare and Execute:
            var obj = new StandardController(new Mock<IForm>().Object, new Mock<IStorage>().Object, new Mock<IDataConverter>().Object);
            // Verify:
            Assert.IsTrue(obj.DataInputDialog != null);
        }

        [TestMethod]
        public void Controller_DataControlMethods_QueringTaskListWorksProperly()
        {
            // Prepare:
            var nameTask = "Task";
            var nameCategory = "Category";
            var list = new List<ITask>();
            var obj = new StandardController(new Mock<IForm>().Object, new Mock<IStorage>().Object, new Mock<IDataConverter>().Object);
            var mockTask = new Mock<ITask>();
            var mockCategory = new Mock<ICategory>();
            mockTask.Setup(x => x.Name).Returns(nameTask);
            mockTask.Setup(x => x.Category).Returns(nameCategory);
            list.Add(mockTask.Object);
            mockCategory.Setup(x => x.Name).Returns(nameCategory);
            mockCategory.Setup(x => x.Tasks).Returns(list);
            obj.Categories.Add(mockCategory.Object);
            // Execute:
            var result = obj.QueryTask(nameTask);
            // Verify:
            Assert.AreEqual(mockTask.Object, result);
        }

        [TestMethod]
        public void Controller_DataControlMethods_QueringCategoryListWorksProperly()
        {
            // Prepare:
            var name = "Category";
            var obj = new StandardController(new Mock<IForm>().Object, new Mock<IStorage>().Object, new Mock<IDataConverter>().Object);
            var mock = new Mock<ICategory>();
            mock.Setup(x => x.Name).Returns(name);
            obj.Categories.Add(mock.Object);
            // Execute:
            var result = obj.QueryCategory(name);
            // Verify:
            Assert.AreEqual(mock.Object, result);
        }

        [DataTestMethod]
        [DataRow(0, "Default")]
        [DataRow(1, "Completed")]
        public void Controller_Methods_LoadMethodSetsCompletedTasksCategoryProperly(int checkIndex, string categoryName)
        {
            // Prepare:
            var storageMock = new Mock<IStorage>();
            var obj = new StandardController(new Mock<IForm>().Object, storageMock.Object, new Mock<IDataConverter>().Object);
            var categoryMock = new Mock<ICategory>();
            categoryMock.Setup(x => x.Name).Returns(categoryName);
            categoryMock.Setup(x => x.Tasks).Returns(new List<ITask>());
            // Execute:
            obj.LoadApp();
            // Verify:
            var result = obj.Categories[checkIndex].EqualsNames(categoryName);
            Assert.IsTrue(result);
        }

        [Ignore]
        [TestMethod]
        public void Controller_Methods_LoadMethodSetsAllCategoriesFromSettings()
        {
            // Prepare:
            var obj = new StandardController(new Mock<IForm>().Object, new Mock<IStorage>().Object, new Mock<IDataConverter>().Object);
            // Execute:
            obj.LoadApp();
            // Verify:
            
        }

        [TestMethod]
        public void Controller_Methods_ChangeSelectedCategoryPerformed()
        {
            // Prepare:
            var form = new Mock<IForm>();
            var obj = new StandardController(form.Object, new Mock<IStorage>().Object, new Mock<IDataConverter>().Object);
            var category = new Mock<ICategory>();
            form.Setup(x => x.SetCurrentCategorySelected(category.Object));
            // Execute:
            obj.ChangeSelectedCategory(category.Object);
            // Verify:
            form.Verify(x => x.SetCurrentCategorySelected(category.Object));
        }

        [TestMethod]
        public void Controller_Methods_ChangeSelectedTaskPerformed()
        {
            // Prepare:
            var form = new Mock<IForm>();
            var obj = new StandardController(form.Object, new Mock<IStorage>().Object, new Mock<IDataConverter>().Object);
            var category = new Mock<ITask>();
            form.Setup(x => x.SetCurrentTaskSelected(category.Object));
            // Execute:
            obj.ChangeSelectedTask(category.Object);
            // Verify:
            form.Verify(x => x.SetCurrentTaskSelected(category.Object));
        }

        [Ignore]
        [TestMethod]
        public void Controller_Methods_ShowsCompletedTaskListInUI()
        { // TODO: Something wrong with mocks here.
            // Prepare:
            var name = "Completed";
            var form = new Mock<IForm>();
            var obj = new StandardController(form.Object, new Mock<IStorage>().Object, new Mock<IDataConverter>().Object);
            var category = new Mock<ICategory>();
            category.Setup(x => x.Name).Returns(name);
            category.Setup(x => x.Tasks).Returns(new List<ITask>());
            form.Setup(x => x.AddCategoryToDisplay(category.Object));
            // Execute:
            obj.ShowCompletedTaskList();
            // Verify:
            form.Verify(x => x.AddCategoryToDisplay(category.Object));
        }

        [Ignore]
        [TestMethod]
        public void Controller_Methods_HidesCompletedTaskListInUI()
        { // TODO: Something wrong with mocks here.
            // Prepare:
            var name = "Completed";
            var form = new Mock<IForm>();
            var obj = new StandardController(form.Object, new Mock<IStorage>().Object, new Mock<IDataConverter>().Object);
            var category = new Mock<ICategory>();
            category.Setup(x => x.Name).Returns(name);
            category.Setup(x => x.Tasks).Returns(new List<ITask>());
            form.Setup(x => x.DeleteCategoryFromDisplay(category.Object));
            // Execute:
            obj.HideCompletedTaskList();
            // Verify:
            form.Verify(x => x.DeleteCategoryFromDisplay(category.Object));
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "Rise exception, only file save is now available.")]
        public void Controller_Methods_SaveCurrentCategoryPerformed()
        {
            // Prepare:
            var storageMock = new Mock<IStorage>();
            storageMock.Setup(x => x.Type).Returns(StorageType.Undefined);
            var obj = new StandardController(new Mock<IForm>().Object, storageMock.Object, new Mock<IDataConverter>().Object);
            // Execute:
            obj.SaveCategory();
        }

        [TestMethod]
        public void Controller_Methods_SaveAllCategoriesPerformed()
        {
            // Prepare:
            // Fake categories:
            var taskMock = new Mock<ITask>();
            taskMock.SetupGet(x => x.Name).Returns("abc");
            var taskMock1 = new Mock<ITask>();
            taskMock1.SetupGet(x => x.Name).Returns("def");
            var taskMock2 = new Mock<ITask>();
            taskMock2.SetupGet(x => x.Name).Returns("ghi");

            // Fake list with tasks:
            var taskList = new List<ITask>
            { 
                taskMock.Object,
                taskMock1.Object,
                taskMock2.Object
            };
            // Fake list of converted categories:
            var stringList = new List<string>
            {
                "<task Name=\"abc\" Description=\"\" StartDate=\"\" EndDate=\"\" Complete=\"\" Category=\"\" />",
                "<task Name=\"def\" Description=\"\" StartDate=\"\" EndDate=\"\" Complete=\"\" Category=\"\" />",
                "<task Name=\"ghi\" Description=\"\" StartDate=\"\" EndDate=\"\" Complete=\"\" Category=\"\" />"
            };

            var storageMock = new Mock<IStorage>();
            var dataConverterMock = new Mock<IDataConverter>();
            dataConverterMock.Setup(x => x.ToObject(taskList)).Returns(stringList);
            var obj = new StandardController(new Mock<IForm>().Object, storageMock.Object, dataConverterMock.Object);
            var categoryMock = new Mock<ICategory>();
            categoryMock.SetupAllProperties();
            obj.Categories.Add(categoryMock.Object);
            obj.Categories[0].Tasks = taskList;
            // Execute:
            obj.SaveAll();
            // Verify:
            storageMock.Verify(x => x.SaveToStorage(StorageSaveMode.Overwrite, stringList), Times.Once);
            storageMock.Verify(x => x.FlushStorage(StorageFlushMode.Save), Times.Once);
            dataConverterMock.Verify(x => x.ToObject(taskList), Times.Once);
        }

        [Ignore]
        [TestMethod]
        public void Controller_Methods_SettingsShownProperly()
        {
            // Prepare:
            var form = new Mock<IForm>();
            var obj = new StandardController(form.Object, new Mock<IStorage>().Object, new Mock<IDataConverter>().Object);
            // Execute:
            obj.ShowSettings();
            // Verify:

        }

        [Ignore]
        [TestMethod]
        public void Controller_Methods_AboutAppShownProperly()
        {
            // Prepare:
            var form = new Mock<IForm>();
            var obj = new StandardController(form.Object, new Mock<IStorage>().Object, new Mock<IDataConverter>().Object);
            // Execute:
            obj.ShowAboutWindow();
            // Verify:

        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "Rise exception, this code is not ready yet.")]
        public void Controller_Methods_NewStorageLoadedProperly()
        {
            // Prepare:
            var storage = new Mock<IStorage>();
            var obj = new StandardController(new Mock<IForm>().Object, storage.Object, new Mock<IDataConverter>().Object);
            var newStorage = new Mock<IStorage>();
            // Execute:
            obj.LoadNewSettings(newStorage.Object);
            // Verify:
            //Assert.AreEqual(newStorage.Object, obj.ActiveStorage);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "Rise exception, this code is not ready yet.")]
        public void Controller_Methods_NewFormLoadedProperly()
        {
            // Prepare:
            var form = new Mock<IForm>();
            var obj = new StandardController(form.Object, new Mock<IStorage>().Object, new Mock<IDataConverter>().Object);
            var newForm = new Mock<IForm>();
            // Execute:
            obj.LoadNewSettings(newForm.Object);
            // Verify:
            //Assert.AreEqual(newStorage.Object, obj.ActiveStorage);
        }
    }
}
