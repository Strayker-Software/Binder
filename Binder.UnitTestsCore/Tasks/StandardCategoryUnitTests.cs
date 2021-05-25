using System;
using System.Collections.Generic;
using Binder.Task;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

/* For copying to new methods:
 // Prepare:

 // Execute:

 // Verify:

 // Prepare and Execute:

*/

namespace Binder.UnitTests.Tasks
{
    [TestClass]
    public class StandardCategoryUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "No exception, Name should not allow null.")]
        public void CategoryClass_Fileds_NameFieldThrowsExceptionOnNullObject()
        {
            // Prepare and Execute:
            _ = new StandardCategory
            {
                Name = null
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "No exception, Name should not empty strings.")]
        public void CategoryClass_Fileds_NameFieldThrowsExceptionOnEmptyString()
        {
            // Prepare and Execute:
            _ = new StandardCategory
            {
                Name = ""
            };
        }

        [TestMethod]
        public void CategoryClass_Fileds_NameFieldGetterWorksCorretly()
        {
            // Prepare and Execute:
            var obj = new StandardCategory()
            {
                Name = "a"
            };
            // Verify:
            Assert.AreEqual("a", obj.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "No exception, Tasks should not allow null.")]
        public void CategoryClass_Fileds_TasksFieldThrowsExceptionOnNullObject()
        {
            // Prepare and Execute:
            _ = new StandardCategory
            {
                Tasks = null
            };
        }

        [TestMethod]
        public void CategoryClass_Fileds_TasksFieldGetterWorksCorretly()
        {
            // Prepare and Execute:
            var list = new List<ITask>();
            var obj = new StandardCategory()
            {
                Tasks = list
            };
            // Verify:
            Assert.AreEqual(list, obj.Tasks);
        }

        [TestMethod]
        public void CategoryClass_Method_EqualMethodWorksForTrue()
        {
            // Prepare:
            var list = new List<ITask>();
            var obj1 = new StandardCategory()
            {
                Name = "name",
                Tasks = list
            };
            var obj2 = new StandardCategory()
            {
                Name = "name",
                Tasks = list
            };
            // Execute:
            var result = obj1.Equals(obj2);
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CategoryClass_Method_EqualMethodWorksForFalse()
        {
            // Prepare:
            var list = new List<ITask>();
            var list1 = new List<ITask>();
            var obj1 = new StandardCategory()
            {
                Name = "name",
                Tasks = list
            };
            var obj2 = new StandardCategory()
            {
                Name = "name1",
                Tasks = list1
            };
            // Execute:
            var result = obj1.Equals(obj2);
            // Verify:
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CategoryClass_Method_EqualNamesMethodWorksForTrue()
        {
            // Prepare:
            var obj1 = new StandardCategory()
            {
                Name = "name"
            };
            var obj2 = new StandardCategory()
            {
                Name = "name"
            };
            // Execute:
            var result = obj1.EqualsNames(obj2.Name);
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CategoryClass_Method_EqualNamesMethodWorksForFalse()
        {
            // Prepare:
            var obj1 = new StandardCategory()
            {
                Name = "name"
            };
            var obj2 = new StandardCategory()
            {
                Name = "name1"
            };
            // Execute:
            var result = obj1.EqualsNames(obj2.Name);
            // Verify:
            Assert.IsFalse(result);
        }
    }
}
