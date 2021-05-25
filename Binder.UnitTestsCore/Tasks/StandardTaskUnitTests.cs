using System;
using Binder.Task;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/* For copying to new methods:
 // Prepare:

 // Execute:

 // Verify:

 // Prepare and Execute:

*/

namespace Binder.UnitTests.Tasks
{
    [TestClass]
    public class StandardTaskUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "No exception, Name should not allow null.")]
        public void TaskClass_Fields_NameFieldThrowsExceptionOnNullObject()
        {
            // Prepare and Execute:
            _ = new StandardTask()
            {
                Name = null
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "No exception, Name should not allow empty string.")]
        public void TaskClass_Fields_NameFieldThrowsExceptionOnEmptyString()
        {
            // Prepare and Execute:
            _ = new StandardTask()
            {
                Name = ""
            };
        }

        [TestMethod]
        public void TaskClass_Fields_NameFieldGetterWorksCorrectly()
        {
            // Prepare and Execute:
            var obj = new StandardTask()
            {
                Name = "a"
            };
            // Verify:
            Assert.AreEqual("a", obj.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "No exception, Description should not allow null.")]
        public void TaskClass_Fields_DescriptionFieldThrowsExceptionOnNullObject()
        {
            // Prepare and Execute:
            _ = new StandardTask()
            {
                Description = null
            };
        }

        [TestMethod]
        public void TaskClass_Fields_DescriptionFieldGetterWorksCorrectly()
        {
            // Prepare and Execute:
            var obj = new StandardTask()
            {
                Description = "a"
            };
            // Verify:
            Assert.AreEqual("a", obj.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "No exception, StartDate should not allow dates beyond UTC start date.")]
        public void TaskClass_Fields_StartDateFieldThrowsExceptionOnToFarAwayDate()
        {
            // Prepare and Execute:
            _ = new StandardTask()
            {
                StartDate = new DateTime(1960, 1, 1, 0, 0, 0) // UTC start date -10 years,
            };
        }

        [TestMethod]
        public void TaskClass_Fields_StartDateFieldGetterWorksCorrectly()
        {
            // Prepare and Execute:
            var time = DateTime.Now;
            var obj = new StandardTask()
            {
                StartDate = time
            };
            // Verify:
            Assert.AreEqual(time, obj.StartDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "No exception, EndDate should not allow dates beyond UTC start date.")]
        public void TaskClass_Fields_EndDateFieldThrowsExceptionOnToFarAwayDate()
        {
            // Prepare and Execute:
            _ = new StandardTask()
            {
                EndDate = new DateTime(1960, 1, 1, 0, 0, 0) // UTC start date -10 years,
            };
        }

        [TestMethod]
        public void TaskClass_Fields_EndDateFieldGetterWorksCorrectly()
        {
            // Prepare and Execute:
            var time = DateTime.Now;
            var obj = new StandardTask()
            {
                EndDate = time
            };
            // Verify:
            Assert.AreEqual(time, obj.EndDate);
        }

        [TestMethod]
        public void TaskClass_Fields_CompleteFieldWorksCorettly()
        {
            // Prepare and Execute:
            var obj = new StandardTask()
            {
                Complete = true
            };

            Assert.AreEqual(true, obj.Complete);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "No exception, Category should not allow null.")]
        public void TaskClass_Fields_CategoryFieldThrowsExceptionOnNullObject()
        {
            // Prepare and Execute:
            _ = new StandardTask()
            {
                Category = null
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "No exception, Category should not allow empty string.")]
        public void TaskClass_Fields_CategoryFieldThrowsExceptionOnEmptyString()
        {
            // Prepare and Execute:
            _ = new StandardTask()
            {
                Category = ""
            };
        }

        [TestMethod]
        public void TaskClass_Fields_CategoryFieldGetterWorksCorrectly()
        {
            // Prepare and Execute:
            var obj = new StandardTask()
            {
                Category = "a"
            };
            // Verify:
            Assert.AreEqual("a", obj.Category);
        }

        [TestMethod]
        public void TaskClass_Constructors_FullDataConstructorWorksCorrectly()
        {
            // Prepare:
            var time = DateTime.Now;
            // Execute:
            var obj = new StandardTask("name", "desc", time, time.AddDays(1), false);
            // Verify:
            Assert.IsTrue(obj.Name == "name" && obj.Description == "desc" && obj.StartDate == time && obj.EndDate == time.AddDays(1) && obj.Complete == false);
        }

        [TestMethod]
        public void TaskClass_Methods_EqualsMethodWorksForTrue()
        {
            // Prepare:
            var time = DateTime.Now;
            var obj1 = new StandardTask("name", "desc", time, time.AddDays(1), false);
            var obj2 = new StandardTask("name", "desc", time, time.AddDays(1), false);
            // Execute:
            var result = obj1.Equals(obj2);
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TaskClass_Methods_EqualsMethodWorksForFalse()
        {
            // Prepare:
            var time = DateTime.Now;
            var obj1 = new StandardTask("name", "desc", time, time.AddDays(1), false);
            var obj2 = new StandardTask("name1", "desc1", time.AddDays(1), time.AddDays(2), true);
            // Execute:
            var result = obj1.Equals(obj2);
            // Verify:
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TaskClass_Methods_EqualsNamesMethodWorksFOrTrue()
        {
            // Prepare:
            var obj1 = new StandardTask
            {
                Name = "name"
            };
            var obj2 = new StandardTask
            {
                Name = "name"
            };
            // Execute:
            var result = obj1.EqualsNames(obj2.Name);
            // Verify:
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TaskClass_Methods_EqualsNamesMethodWorksFOrFalse()
        {
            // Prepare:
            var obj1 = new StandardTask
            {
                Name = "name"
            };
            var obj2 = new StandardTask
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
