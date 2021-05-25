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
    public class CategoryFactoryUnitTests
    {
        [TestMethod]
        public void Factory_FactoryMethod_GetStandardCategoryObject()
        {
            // Prepare:
            var obj = new CategoryFactory();
            // Execute:
            var result = obj.GetCategory(ECategory.Standard);
            // Verify:
            Assert.IsInstanceOfType(result, typeof(StandardCategory));
        }

        [TestMethod]
        public void Factory_FactoryMethod_GetNullObject()
        {
            // Prepare:
            var obj = new CategoryFactory();
            // Execute:
            var result = obj.GetCategory(ECategory.None);
            // Verify:
            Assert.IsNull(result);
        }
    }
}
