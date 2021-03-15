using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Binder.Storages;

/* For copying to new methods:
 // Prepare:

 // Execute:

 // Verify:
 // Prepare and Execute:
 */

namespace Binder.UnitTests.Storages
{
    [TestClass]
    public class DataGridViewXMLStorageUnitTests
    {
        [TestMethod]
        public void Storage_DataControl_NewPathInObject()
        {
            // Prepare:
#pragma warning disable IDE0017 // Simplify object init,
            var strgm = new DataGridViewStorageManagerXML();
#pragma warning restore IDE0017 // Simplify object init,
            // Execute:
            strgm.StorageAccess = "databases\\Page1.xml";
            // Verify:
            Assert.AreEqual("databases\\Page1.xml", strgm.StorageAccess);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when given path is null.")]
        public void Storage_DataControl_StoragePathIsNotNull()
        {
            // Prepare:
#pragma warning disable IDE0017 // Simplify object init,
            var strgm = new DataGridViewStorageManagerXML();
#pragma warning restore IDE0017 // Simplify object init,
            // Execute:
            strgm.StorageAccess = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rise exception when given path is empty.")]
        public void Storage_DataControl_StoragePathIsNotEmpty()
        {
            // Prepare:
#pragma warning disable IDE0017 // Simplify object init,
            var strgm = new DataGridViewStorageManagerXML();
#pragma warning restore IDE0017 // Simplify object init,
            // Execute:
            strgm.StorageAccess = "";
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException), "Rise exception when given path directs to nothing.")]
        public void Storage_DataControl_DatabaseFileDoesntExist()
        {
            // Prepare:
#pragma warning disable IDE0017 // Simplify object init,
            var strgm = new DataGridViewStorageManagerXML();
#pragma warning restore IDE0017 // Simplify object init,
            // Execute:
            strgm.StorageAccess = "file.txt"; // Fake file,
        }
    }
}
