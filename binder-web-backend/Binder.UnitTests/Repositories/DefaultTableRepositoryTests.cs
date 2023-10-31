using Binder.Core.Models;
using Binder.Persistence.Contexts;
using Binder.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq.EntityFrameworkCore;

namespace Binder.UnitTests.Repositories
{
    public class DefaultTableRepositoryTests
    {
        private readonly MockRepository _mockRepository;
        private readonly Mock<BinderDbContext> _mockTestDbContext;
        private readonly ToDoTask _testTaskData = new() { Name = "a" };
        private readonly DefaultTable _testTableData = new();

        public DefaultTableRepositoryTests()
        {
            this._mockRepository = new MockRepository(MockBehavior.Strict);

            this._mockTestDbContext = this._mockRepository.Create<BinderDbContext>();
            _mockTestDbContext.SetupSet(x => x.Tables = It.IsAny<DbSet<DefaultTable>>()).CallBase();
            _mockTestDbContext.SetupGet(x => x.Tables).ReturnsDbSet(new List<DefaultTable>() { _testTableData });
            _mockTestDbContext.SetupSet(x => x.ToDoTasks = It.IsAny<DbSet<ToDoTask>>()).CallBase();
            _mockTestDbContext.SetupGet(x => x.ToDoTasks).ReturnsDbSet(new List<ToDoTask>() { _testTaskData });
            _mockTestDbContext.Setup(x => x.Dispose()).Verifiable();
        }

        private DefaultTableRepository CreateDefaultTableRepository()
        {
            return new DefaultTableRepository(
                _mockTestDbContext.Object);
        }

        [Fact]
        public void GetBaseEntities_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var repo = this.CreateDefaultTableRepository();

            // Act
            var result = repo.GetTableById(0);

            // Assert
            result.Should().BeEquivalentTo(_testTableData);
        }

        [Fact]
        public void Dispose_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var repo = this.CreateDefaultTableRepository();

            // Act
            repo.Dispose();

            // Assert
            _mockTestDbContext.Verify(x => x.Dispose());
        }
    }
}