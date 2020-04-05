using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Binder.UnitTests
{
    [TestClass]
    public class StorageUnitTests
    {
        [TestMethod]
        public void Storage_SetAndGetDatabasePath_NewPathInObject()
        {
            // Prepare:
            var strgm = new StorageManager();
            // Execute:
            strgm.StoragePath = "Data.txt";
            // Verify:
            Assert.AreEqual("Data.txt", strgm.StoragePath);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when given path is null.")]
        public void Storage_DataControl_StoragePathIsNotNull()
        {
            // Prepare:
            var strgm = new StorageManager();
            // Execute:
            strgm.StoragePath = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when given path is empty.")]
        public void Storage_DataControl_StoragePathIsNotEmpty()
        {
            // Prepare:
            var strgm = new StorageManager();
            // Execute:
            strgm.StoragePath = "";
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException), "Rise exception when given path directs to nothing.")]
        public void Storage_DataControl_DatabaseFileDoesntExist()
        {
            // Prepare:
            var strgm = new StorageManager();
            // Execute:
            strgm.StoragePath = "file.txt"; // Fake file
        }

        [TestMethod]
        public void Storage_UpdateDatabase_NewDataInDatabase()
        {
            /*
                WARINING!
                This test has file system dependency
                and doesn't follow TDD rules.
                I will work over the test and it's test objects
                to satisfy TDD rules in future development.
            */

            // Prepare:
            var strgm = new StorageManager();
            strgm.StoragePath = "Data.txt";
            // Execute:
            strgm.SaveToStorage("abc");
            // Verify:
            var reader = new StreamReader("Data.txt");
            var readData = reader.ReadToEnd();
            Assert.AreEqual("abc", readData);
        }

        [TestMethod]
        public void Storage_GetDataFromDatabase_NewDataLoadedFromBase()
        {
            /*
                WARINING!
                This test has file system dependency
                and doesn't follow TDD rules.
                I will work over the test and it's test objects
                to satisfy TDD rules in future development.
            */

            // Prepare:
            var strgm = new StorageManager();
            strgm.StoragePath = "Data.txt";
            strgm.SaveToStorage("abc");
            // Execute:
            var data = strgm.LoadFromStorage();
            // Verify:
            Assert.AreEqual("abc", data);
        }
    }
}
