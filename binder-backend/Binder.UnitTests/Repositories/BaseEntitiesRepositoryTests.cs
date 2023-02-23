using Binder.Core.Models;
using Binder.Infrastructure.Contexts;
using Binder.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq.EntityFrameworkCore;

namespace Binder.UnitTests.Repositories
{
    public class BaseEntitiesRepositoryTests
    {
        private readonly MockRepository _mockRepository;
        private readonly Mock<TestDbContext> _mockTestDbContext;
        private readonly ICollection<BaseEntity> _testData = new List<BaseEntity> { new BaseEntity("a") };

        public BaseEntitiesRepositoryTests()
        {
            this._mockRepository = new MockRepository(MockBehavior.Strict);

            this._mockTestDbContext = this._mockRepository.Create<TestDbContext>();
            _mockTestDbContext.SetupSet(x => x.BaseEntities = It.IsAny<DbSet<BaseEntity>>()).CallBase();
            _mockTestDbContext.SetupGet(x => x.BaseEntities).ReturnsDbSet(_testData);
            _mockTestDbContext.Setup(x => x.Dispose()).Verifiable();
        }

        private BaseEntitiesRepository CreateBaseEntitiesRepository()
        {
            return new BaseEntitiesRepository(
                this._mockTestDbContext.Object);
        }

        [Fact]
        public void GetBaseEntities_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var baseEntitiesRepository = this.CreateBaseEntitiesRepository();

            // Act
            var result = baseEntitiesRepository.GetBaseEntities();

            // Assert
            result.Should().BeEquivalentTo(_testData);
        }

        [Fact]
        public void Dispose_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var baseEntitiesRepository = this.CreateBaseEntitiesRepository();

            // Act
            baseEntitiesRepository.Dispose();

            // Assert
            _mockTestDbContext.Verify(x => x.Dispose());
        }
    }
}