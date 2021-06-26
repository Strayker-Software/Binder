using System;
using System.IO;
using System.Collections.Generic;
using Binder.Data.Storage;
using Binder.Data.Storage.Files;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Text;

/* For copying to new methods:
 // Prepare:

 // Execute:

 // Verify:

 // Prepare and Execute:

*/

namespace Binder.UnitTests.Data.Storage
{
    [TestClass]
    public class FileStorageManagerUnitTests
    {
        [TestMethod]
        public void StorageAccess_Constructor_ConstructorSetsLocationProperly()
        {
            // Prepare:
            var path = Environment.CurrentDirectory;
            var fsMock = new Mock<IFileSystemAccess>();
            fsMock.Setup(x => x.Exists(path)).Returns(true); // Bypass file path control,
            // Execute:
            var obj = new FileStorageManager(fsMock.Object, path);
            // Verify:
            Assert.AreEqual(path, obj.Location);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Constructor allowed empty path to Location property.")]
        public void StorageAccess_Constructor_ConstructorThrowsExceptionOnEmptyPath()
        {
            // Prepare:
            var fsMock = new Mock<IFileSystemAccess>();
            fsMock.Setup(x => x.Exists(string.Empty)).Returns(false); // Empty string provided, 
            // Execute:
            var obj = new FileStorageManager(fsMock.Object, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Constructor allowed null path to Location property.")]
        public void StorageAccess_Constructor_ConstructorThrowsExceptionOnNullPath()
        {
            // Prepare:
            var fsMock = new Mock<IFileSystemAccess>();
            fsMock.Setup(x => x.Exists(null)).Returns(false); // Empty string provided, 
            // Execute:
            var obj = new FileStorageManager(fsMock.Object, null);
        }

        [TestMethod]
        public void StorageAccess_Fields_LocationSetterAndGetterWorksProperly()
        {
            // Prepare:
            var path = Environment.CurrentDirectory;
            var fsMock = new Mock<IFileSystemAccess>();
            fsMock.Setup(x => x.Exists(path)).Returns(true); // Bypass file path control,
            fsMock.Setup(x => x.Exists("XD")).Returns(true); // Bypass file path control,
            // Execute:
            var obj = new FileStorageManager(fsMock.Object, "XD")
            {
                Location = path
            };
            // Verify:
            Assert.AreEqual(path, obj.Location);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Setter of Location property allowed empty string.")]
        public void StorageAccess_Fields_LocationFieldThrowsExceptionOnEmptyPath()
        {
            // Prepare:
            var path = Environment.CurrentDirectory;
            var fsMock = new Mock<IFileSystemAccess>();
            fsMock.Setup(x => x.Exists(path)).Returns(true); // Bypass file path control,
            // Execute:
            var obj = new FileStorageManager(fsMock.Object, path)
            {
                Location = string.Empty
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Setter of Location property allowed null.")]
        public void StorageAccess_Fields_LocationFieldThrowsExceptionOnNullPath()
        {
            // Prepare:
            var path = Environment.CurrentDirectory;
            var fsMock = new Mock<IFileSystemAccess>();
            fsMock.Setup(x => x.Exists(path)).Returns(true); // Bypass file path control,
            // Execute:
            var obj = new FileStorageManager(fsMock.Object, path)
            {
                Location = null
            };
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException), "Setter of Location property allowed not existing file.")]
        public void StorageAccess_Fields_LocationFieldThrowsExceptionOnNotExistingPath()
        {
            // Prepare:
            var path = Environment.CurrentDirectory;
            var fsMock = new Mock<IFileSystemAccess>();
            fsMock.Setup(x => x.Exists(path)).Returns(true); // Bypass file path control,
            // Execute:
            var obj = new FileStorageManager(fsMock.Object, path)
            {
                Location = @"C:/XDDDDD"
            };
        }

        [TestMethod]
        public void StorageAccess_Constructor_ObjectInitialisedProperly()
        {
            // Prepare:
            var path = Environment.CurrentDirectory;
            var fsMock = new Mock<IFileSystemAccess>();
            fsMock.Setup(x => x.Exists(path)).Returns(true); // Bypass file path control,
            // Execute:
            var obj = new FileStorageManager(fsMock.Object, path);
            // Verify:
            Assert.IsNotNull(obj.Location);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Faulty path accepted by constructor.")]
        public void StorageAccess_Constructor_FaultArgumentCauseException()
        {
            // Prepare:
            var path = Environment.CurrentDirectory;
            var fsMock = new Mock<IFileSystemAccess>();
            fsMock.Setup(x => x.Exists(path)).Returns(false); // Bypass file path control, force exception,
            // Execute:
            var obj = new FileStorageManager(fsMock.Object, path);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Constructor is accessing file system by null value.")]
        public void StorageAccess_Constructor_ThrowsExceptionOnNullFileSystemAccess()
        {
            // Prepare:
            var path = Environment.CurrentDirectory;
            // Execute:
            _ = new FileStorageManager(null, path);
        }

        [TestMethod]
        public void StorageAccess_Methods_LoadedDataFromMemoryAtIndexReturnsNull()
        {
            // Prepare:
            var path = Environment.CurrentDirectory;
            var fsMock = new Mock<IFileSystemAccess>();
            fsMock.Setup(x => x.Exists(path)).Returns(true); // Bypass file path control,
            var obj = new FileStorageManager(fsMock.Object, path);
            // Execute:
            var result = obj.LoadFromStorage(1); // First index points to header of data convertion,
            // Verify:
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "LoadFromStorage allowed faulty index value.")]
        public void StorageAccess_Methods_LoadingDataFromMemoryAtFaultIndexThrowsException()
        {
            // Prepare:
            var path = Environment.CurrentDirectory;
            var fsMock = new Mock<IFileSystemAccess>();
            fsMock.Setup(x => x.Exists(path)).Returns(true); // Bypass file path control,
            var obj = new FileStorageManager(fsMock.Object, path);
            // Execute:
            var result = obj.LoadFromStorage(-5);
            // Verify:
            Assert.AreEqual(null, result);
        }

        [Ignore]
        [TestMethod]
        public void StorageAccess_Methods_LoadingAllDataFromMemoryProperly()
        { // TODO: FileStorageManager is too dependent on Settings class in LoadFromStorage, need to change that.
            // Prepare:
            var list = new List<string>()
            {
                "abc"
            };
            var path = Environment.CurrentDirectory;
            var fsMock = new Mock<IFileSystemAccess>();
            fsMock.Setup(x => x.Exists(path)).Returns(true); // Bypass file path control,
            var obj = new FileStorageManager(fsMock.Object, path);
            // Execute:
            var result = obj.LoadFromStorage();
            // Verify:
            CollectionAssert.AreEqual(list, (List<string>)result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "SaveToStorage allowed saving at not existing index.")]
        public void StorageAccess_Methods_SavingDataAtFaultIndexThrowsException()
        {
            // Prepare:
            var path = Environment.CurrentDirectory;
            var fsMock = new Mock<IFileSystemAccess>();
            fsMock.Setup(x => x.Exists(path)).Returns(true); // Bypass file path control,
            var obj = new FileStorageManager(fsMock.Object, path);
            // Execute:
            obj.SaveToStorage(-1, string.Empty);
        }

        [TestMethod]
        public void StorageAccess_Methods_SavingDataAtIndexProperly()
        {
            // Prepare:
            var path = Environment.CurrentDirectory;
            var fsMock = new Mock<IFileSystemAccess>();
            fsMock.Setup(x => x.Exists(path)).Returns(true); // Bypass file path control,
            var obj = new FileStorageManager(fsMock.Object, path);
            // Execute:
            obj.SaveToStorage(0, string.Empty);
        }

        [TestMethod]
        public void StorageAccess_Methods_SaveAllDataToMemoryProperly()
        {
            // Prepare:
            var path = Environment.CurrentDirectory;
            var fsMock = new Mock<IFileSystemAccess>();
            fsMock.Setup(x => x.Exists(path)).Returns(true); // Bypass file path control,
            var obj = new FileStorageManager(fsMock.Object, path);
            var list = new List<string>
            {
                string.Empty,
                "Hello!",
                string.Empty
            };
            // Execute:
            obj.SaveToStorage(StorageSaveMode.Overwrite, list);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "SaveToStorage allowed empty list to memory buffer.")]
        public void StorageAccess_Methods_SaveAllEmptyDataThrowsException()
        {
            // Prepare:
            var path = Environment.CurrentDirectory;
            var fsMock = new Mock<IFileSystemAccess>();
            fsMock.Setup(x => x.Exists(path)).Returns(true); // Bypass file path control,
            var obj = new FileStorageManager(fsMock.Object, path);
            var list = new List<string>();
            // Execute:
            obj.SaveToStorage(StorageSaveMode.Overwrite, list);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "SaveToStorage allowed null to memory buffer.")]
        public void StorageAccess_Methods_SaveWithNullThrowsException()
        {
            // Prepare:
            var path = Environment.CurrentDirectory;
            var fsMock = new Mock<IFileSystemAccess>();
            fsMock.Setup(x => x.Exists(path)).Returns(true); // Bypass file path control,
            var obj = new FileStorageManager(fsMock.Object, path);
            // Execute:
            obj.SaveToStorage(null);
        }

        [TestMethod]
        public void StorageAccess_Methods_RefreshLoadPerformedCorectly()
        {
            // Prepare:
            var path = Environment.CurrentDirectory;
            var fsMock = new Mock<IFileSystemAccess>();
            fsMock.Setup(x => x.Exists(path)).Returns(true); // Bypass file path control,
            var enc = new UnicodeEncoding();

            // Make fake file stream with only two letters:
            var memStream = new MemoryStream();
            memStream.Write(enc.GetBytes("XD"));
            memStream.Seek(0, SeekOrigin.Begin);
            var fileStreamMock = new Mock<StreamReader>(memStream);
            fsMock.Setup(x => x.GetFileStreamReader(path)).Returns(fileStreamMock.Object);

            var obj = new FileStorageManager(fsMock.Object, path);
            // Execute:
            obj.FlushStorage(StorageFlushMode.Load);
            // Verify:
            fileStreamMock.Verify(x => x.ReadLine(), Times.AtLeastOnce);
            fsMock.Verify(x => x.GetFileStreamReader(path), Times.Once);
        }

        [TestMethod]
        public void StorageAccess_Methods_RefreshSavePerformedCorectly()
        {
            // Prepare:
            var path = Environment.CurrentDirectory;
            var fsMock = new Mock<IFileSystemAccess>();
            fsMock.Setup(x => x.Exists(path)).Returns(true); // Bypass file path control,

            // Make fake file stream:
            var memStream = new MemoryStream();
            var fileStreamMock = new Mock<StreamWriter>(memStream);
            fsMock.Setup(x => x.GetFileStreamWriter(path)).Returns(fileStreamMock.Object);

            var obj = new FileStorageManager(fsMock.Object, path);
            // Execute:
            obj.FlushStorage(StorageFlushMode.Save);
            // Verify:
            fsMock.Verify(x => x.Delete(path), Times.Once);
            fsMock.Verify(x => x.GetFileStreamWriter(path), Times.Once);
            fileStreamMock.Verify(x => x.WriteLine(), Times.Never); // Because buffer is not containing any data,
        }

        [TestMethod]
        public void StorageAccess_Methods_ReturnOnNoneOperationMode()
        {
            // Prepare:
            var path = Environment.CurrentDirectory;
            var fsMock = new Mock<IFileSystemAccess>();
            fsMock.Setup(x => x.Exists(path)).Returns(true); // Bypass file path control,
            var obj = new FileStorageManager(fsMock.Object, path);
            // Execute:
            obj.FlushStorage(StorageFlushMode.None);
        }
    }
}
