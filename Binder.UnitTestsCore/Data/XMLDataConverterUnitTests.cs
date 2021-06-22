using System;
using System.Collections.Generic;
using Binder.Data;
using Binder.Task;
using Binder.Task.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

/* For copying to new methods:
 // Prepare:

 // Execute:

 // Verify:

 // Prepare and Execute:

*/

namespace Binder.UnitTests.Data
{
    [TestClass]
    public class XMLDataConverterUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "Getter of XMLDataConverter.Separator is implemented?")]
        public void DataConvertion_Properties_SeparatorGetterThrowsNotImplementedException()
        {
            // Prepare and Execute:
            var obj = new XMLDataConverter();
            _ = obj.Separator;
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "Setter of XMLDataConverter.Separator is implemented?")]
        public void DataConvertion_Properties_SeparatorSetterThrowsNotImplementedException()
        {
            // Prepare and Execute:
            _ = new XMLDataConverter
            {
                Separator = 'a'
            };
        }

        [TestMethod]
        public void DataConvertion_Methods_StringConvertedToITaskObject()
        {
            // Prepare:
            var obj = new XMLDataConverter();
            var data = "<task Name=\"TaskName\" Description=\"TaskDescription\" StartDate=\"01.01.2021 00:00:00\" EndDate=\"02.01.2021 00:00:05\" Complete=\"True\" Category=\"TaskCategory\" />";
            var taskMock = new Mock<ITask>();
            taskMock.SetupAllProperties();
            // Execute:
            obj.ToObject(taskMock.Object, data);
            // Verify:
            taskMock.VerifySet(x => x.Name = "TaskName");
            taskMock.VerifySet(x => x.Description = "TaskDescription");
            taskMock.VerifySet(x => x.StartDate = DateTime.Parse("01.01.2021 00:00:00"));
            taskMock.VerifySet(x => x.EndDate = DateTime.Parse("02.01.2021 00:00:05"));
            taskMock.VerifySet(x => x.Complete = true);
            taskMock.VerifySet(x => x.Category = "TaskCategory");
        }

        [TestMethod]
        public void DataConvertion_Methods_StringConvertionToITaskObjectFailed()
        {
            // Prepare:
            var obj = new XMLDataConverter();
            var data = "<task Name=\"\" Description=\"\" StartDate=\"\" EndDate=\"\" Complete=\"\" Category=\"\" />";
            var taskMock = new Mock<ITask>();
            // Execute:
            var result = obj.ToObject(taskMock.Object, data);
            // Verify:
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DataConvertion_Methods_WrongXMLStringInStringConvertionToITaskObjectFails()
        {
            // Prepare:
            var obj = new XMLDataConverter();
            var data = "abc";
            var taskMock = new Mock<ITask>();
            // Execute:
            var result = obj.ToObject(taskMock.Object, data);
            // Verify:
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DataConvertion_Methods_ListOfStringsConvertedToListOfITaskObjects()
        {
            // Prepare:
            var obj = new XMLDataConverter();
            var data = "<task Name=\"TaskName\" Description=\"TaskDescription\" StartDate=\"01.01.2021 00:00:00\" EndDate=\"02.01.2021 00:00:05\" Complete=\"True\" Category=\"TaskCategory\" />";
            var taskMock = new Mock<ITask>();
            taskMock.Setup(x => x.Name).Returns("TaskName");
            taskMock.Setup(x => x.Description).Returns("TaskDescription");
            taskMock.Setup(x => x.StartDate).Returns(DateTime.Parse("2021-01-01 00:00:00"));
            taskMock.Setup(x => x.EndDate).Returns(DateTime.Parse("2021-01-02 00:00:05"));
            taskMock.Setup(x => x.Complete).Returns(true);
            taskMock.Setup(x => x.Category).Returns("TaskCategory");
            var listString = new List<string>
            {
                data,
                data,
                data
            };
            var listTask = new List<ITask>
            {
                taskMock.Object,
                taskMock.Object,
                taskMock.Object
            };
            var factoryMock = new Mock<ITaskFactory>();
            factoryMock.Setup(x => x.GetTask(ETask.Standard)).Returns(taskMock.Object);
            // Execute:
            var result = obj.ToObject(factoryMock.Object, listString);
            // Verify:
            CollectionAssert.AreEqual(listTask, (List<ITask>)result);
        }

        [TestMethod]
        public void DataConvertion_Methods_ListOfStringsConvertedToListOfITaskObjectsWithOneNull()
        {
            // Prepare:
            var obj = new XMLDataConverter();
            var data = "<task Name=\"TaskName\" Description=\"TaskDescription\" StartDate=\"01.01.2021 00:00:00\" EndDate=\"02.01.2021 00:00:05\" Complete=\"True\" Category=\"TaskCategory\" />";
            var wrongData = "<task Name=\"\" Description=\"\" StartDate=\"\" EndDate=\"\" Complete=\"\" Category=\"\" />";
            var taskMock = new Mock<ITask>();
            taskMock.SetupAllProperties();
            var listString = new List<string>
            {
                data,
                wrongData,
                data
            };
            // Execute:
            var result = obj.ToObject(new Mock<ITaskFactory>().Object, listString);
            // Verify:
            CollectionAssert.Contains((List<ITask>)result, null);
        }

        [TestMethod]
        public void DataConvertion_Methods_ITaskObjectConvertedToXMLString()
        {
            // Prepare:
            var obj = new XMLDataConverter();
            var data = "<task Name=\"TaskName\" Description=\"TaskDescription\" StartDate=\"01.01.2021 00:00:00\" EndDate=\"02.01.2021 00:00:05\" Complete=\"True\" Category=\"TaskCategory\" />";
            var taskMock = new Mock<ITask>();
            taskMock.Setup(x => x.Name).Returns("TaskName");
            taskMock.Setup(x => x.Description).Returns("TaskDescription");
            taskMock.Setup(x => x.StartDate).Returns(DateTime.Parse("2021-01-01 00:00:00"));
            taskMock.Setup(x => x.EndDate).Returns(DateTime.Parse("2021-01-02 00:00:05"));
            taskMock.Setup(x => x.Complete).Returns(true);
            taskMock.Setup(x => x.Category).Returns("TaskCategory");
            // Execute:
            var result = obj.ToObject(taskMock.Object);
            // Verify:
            Assert.AreEqual(data, result);
        }

        [TestMethod]
        public void DataConvertion_Methods_WrongITaskObjectConvertionToXML()
        {
            // Prepare:
            var obj = new XMLDataConverter();
            var taskMock = new Mock<ITask>();
            // Execute:
            var result = obj.ToObject(taskMock.Object);
            // Verify:
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DataConvertion_Methods_ListOfITaskObjectsConvertedToListOfStringObjects()
        {
            // Prepare:
            var obj = new XMLDataConverter();
            var data = "<task Name=\"TaskName\" Description=\"TaskDescription\" StartDate=\"01.01.2021 00:00:00\" EndDate=\"02.01.2021 00:00:05\" Complete=\"True\" Category=\"TaskCategory\" />";
            var taskMock = new Mock<ITask>();
            taskMock.Setup(x => x.Name).Returns("TaskName");
            taskMock.Setup(x => x.Description).Returns("TaskDescription");
            taskMock.Setup(x => x.StartDate).Returns(DateTime.Parse("01.01.2021 00:00:00"));
            taskMock.Setup(x => x.EndDate).Returns(DateTime.Parse("02.01.2021 00:00:05"));
            taskMock.Setup(x => x.Complete).Returns(true);
            taskMock.Setup(x => x.Category).Returns("TaskCategory");
            var listString = new List<string>
            {
                data,
                data,
                data
            };
            var listTask = new List<ITask>
            {
                taskMock.Object,
                taskMock.Object,
                taskMock.Object
            };
            // Execute:
            var result = obj.ToObject(listTask);
            // Verify:
            CollectionAssert.AreEqual(listString, (List<string>)result);
        }

        [TestMethod]
        public void DataConvertion_Methods_ListOfITaskObjectsConvertedToListOfStringObjectsWithOneNull()
        {
            // Prepare:
            var obj = new XMLDataConverter();
            var taskMock = new Mock<ITask>();
            taskMock.Setup(x => x.Name).Returns("TaskName");
            taskMock.Setup(x => x.Description).Returns("TaskDescription");
            taskMock.Setup(x => x.StartDate).Returns(DateTime.Parse("01.01.2021 00:00:00"));
            taskMock.Setup(x => x.EndDate).Returns(DateTime.Parse("02.01.2021 00:00:05"));
            taskMock.Setup(x => x.Complete).Returns(true);
            taskMock.Setup(x => x.Category).Returns("TaskCategory");
            var wrongTaskMock = new Mock<ITask>();
            var listTask = new List<ITask>
            {
                taskMock.Object,
                wrongTaskMock.Object,
                taskMock.Object
            };
            // Execute:
            var result = obj.ToObject(listTask);
            // Verify:
            CollectionAssert.Contains((List<string>)result, null);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "Not for use, maybe in next versions.")]
        public void DataConvertion_Methods_StringObjectConvertedToICategoryObject()
        {
            // Prepare and Execute:
            var obj = new XMLDataConverter();
            obj.ToObject(new Mock<ICategory>().Object, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "Not for use, maybe in next versions.")]
        public void DataConvertion_Properties_ListOfStringObjectsConvertedToListOfICategoryObjects()
        {
            // Prepare and Execute:
            var obj = new XMLDataConverter();
            var list = new List<string>()
            { 
                string.Empty,
                string.Empty,
                string.Empty
            };
            obj.ToObject(new Mock<ICategory>().Object, list);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "Not for use, maybe in next versions.")]
        public void DataConvertion_Methods_ICategoryObjectConvertedToStringObject()
        {
            // Prepare and Execute:
            var obj = new XMLDataConverter();
            obj.ToObject(new Mock<ICategory>().Object);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "Not for use, maybe in next versions.")]
        public void DataConvertion_Methods_ListOfICategoryObjectsConvertedToListOfStringObjects()
        {
            // Prepare and Execute:
            var obj = new XMLDataConverter();
            var list = new List<ICategory>()
            {
                new Mock<ICategory>().Object,
                new Mock<ICategory>().Object,
                new Mock<ICategory>().Object
            };
            obj.ToObject(list);
        }
    }
}
