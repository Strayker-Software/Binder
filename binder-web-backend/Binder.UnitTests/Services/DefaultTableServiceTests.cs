using Binder.Application.Services;
using Binder.Core.Models;
using Binder.Persistence.Models.Interfaces;

namespace Binder.UnitTests.Services
{
    public class DefaultTableServiceTests
    {
        private readonly MockRepository mockRepository;

        private readonly Mock<IDefaultTableRepository> mockTestRepository;

        public DefaultTableServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockTestRepository = this.mockRepository.Create<IDefaultTableRepository>();
            this.mockTestRepository.Setup(x => x.GetTaskById(It.IsAny<int>())).Returns(new ToDoTask() { Name = "a" });
        }

        private DefaultTableService CreateService()
        {
            return new DefaultTableService(
                this.mockTestRepository.Object);
        }

        [Fact]
        public void GetTask_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();

            // Act
            var result = service.GetTask(0);

            // Assert
            result.Name.Should().Be("a");
        }
    }
}