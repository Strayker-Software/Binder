using Binder.Application.Services;
using Binder.Core.Models;
using Binder.Infrastructure.Models.Interfaces;

namespace Binder.UnitTests.Services
{
    public class TestServiceTests
    {
        private readonly MockRepository mockRepository;

        private readonly Mock<ITestRepository> mockTestRepository;

        public TestServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockTestRepository = this.mockRepository.Create<ITestRepository>();
            this.mockTestRepository.Setup(x => x.GetBaseEntities()).Returns(new List<BaseEntity> { new BaseEntity("a") });
        }

        private TestService CreateService()
        {
            return new TestService(
                this.mockTestRepository.Object);
        }

        [Fact]
        public void GetFirstEntityName_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();

            // Act
            var result = service.GetFirstEntityName();

            // Assert
            result.Should().Be("a");
        }
    }
}