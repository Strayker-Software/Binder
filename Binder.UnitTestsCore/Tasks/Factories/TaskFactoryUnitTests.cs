using System;
using Binder.Task;
using Binder.Task.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/* For copying to new methods:
 // Prepare:

 // Execute:

 // Verify:

 // Prepare and Execute:

*/

namespace Binder.UnitTests.Tasks.Factories
{
    [TestClass]
    public class TaskFactoryUnitTests
    {
        [TestMethod]
        public void Factory_FactoryMethod_GetStandardTaskObject()
        {
            // Prepare:
            var obj = new TaskFactory();
            // Execute:
            var result = obj.GetTask(ETask.Standard);
            // Verify:
            Assert.IsInstanceOfType(result, typeof(StandardTask));
        }

        [TestMethod]
        public void Factory_FactoryMethod_GetNullObject()
        {
            // Prepare:
            var obj = new TaskFactory();
            // Execute:
            var result = obj.GetTask(ETask.None);
            // Verify:
            Assert.IsNull(result);
        }
    }
}
