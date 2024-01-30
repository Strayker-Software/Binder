using Binder.Core.Models;
using Binder.Persistence.Contexts;
using Binder.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq.EntityFrameworkCore;

namespace Binder.UnitTests.Repositories
{
    public sealed class DefaultTableRepositoryTests
    {
        private readonly MockRepository _mockRepository;
        private readonly Mock<BinderDbContext> _mockHappyPathTestDbContext;
        private readonly Mock<BinderDbContext> _mockSadPathTestDbContext;
        private readonly ToDoTask _testTaskData = new() { Name = "a" };
        private readonly DefaultTable _testTableDataOne = new() { Id = 1 };
        private readonly DefaultTable _testTableDataTwo = new() { Id = 2 };
        private readonly DefaultTable _testTableDataThree = new() { Id = 3 };
        private readonly List<DefaultTable> _testTableListData;
        private const int _testTableId = 2;

        public DefaultTableRepositoryTests()
        {
            _testTableListData = new List<DefaultTable>()
            {
                _testTableDataOne,
                _testTableDataTwo,
                _testTableDataThree
            };

            _mockRepository = new MockRepository(MockBehavior.Strict);

            _mockHappyPathTestDbContext = _mockRepository.Create<BinderDbContext>();
            _mockHappyPathTestDbContext.SetupSet(x => x.Tables = It.IsAny<DbSet<DefaultTable>>()).CallBase();
            _mockHappyPathTestDbContext.SetupGet(x => x.Tables)
                .ReturnsDbSet(_testTableListData);
            _mockHappyPathTestDbContext.SetupSet(x => x.ToDoTasks = It.IsAny<DbSet<ToDoTask>>()).CallBase();
            _mockHappyPathTestDbContext.SetupGet(x => x.ToDoTasks).ReturnsDbSet(new List<ToDoTask>() { _testTaskData });
            _mockHappyPathTestDbContext.Setup(x => x.Dispose()).Verifiable();

            _mockSadPathTestDbContext = _mockRepository.Create<BinderDbContext>();
            _mockSadPathTestDbContext.SetupSet(x => x.Tables = It.IsAny<DbSet<DefaultTable>>()).CallBase();
            _mockSadPathTestDbContext.SetupGet(x => x.Tables).ReturnsDbSet(new List<DefaultTable>());
            _mockSadPathTestDbContext.SetupSet(x => x.ToDoTasks = It.IsAny<DbSet<ToDoTask>>()).CallBase();
            _mockSadPathTestDbContext.SetupGet(x => x.ToDoTasks).ReturnsDbSet(new List<ToDoTask>());
            _mockSadPathTestDbContext.Setup(x => x.Dispose()).Verifiable();
        }

        [Fact]
        public void DefaultTable_GetById_ReturnsCorrectTableData()
        {
            // Arrange
            var repo = CreateDefaultTableRepository(_mockHappyPathTestDbContext);

            // Act
            var result = repo.GetById(_testTableId);

            // Assert
            result.Should().BeEquivalentTo(_testTableDataTwo);
        }

        [Fact]
        public void DefaultTable_GetAll_ReturnsCorrectTablesData()
        {
            // Arrange
            var repo = CreateDefaultTableRepository(_mockHappyPathTestDbContext);

            // Act
            var result = repo.GetAll();

            // Assert
            result.Should().BeEquivalentTo(_testTableListData);
        }

        [Fact]
        public void Object_CallDisposeInCode_InternalDisposeCalledInHappyPath()
        {
            // Arrange
            var repo = CreateDefaultTableRepository(_mockHappyPathTestDbContext);

            // Act
            repo.Dispose();

            // Assert
            _mockHappyPathTestDbContext.Verify(x => x.Dispose());
        }

        [Fact]
        public void DefaultTable_GetById_ReturnsNull()
        {
            // Arrange
            var repo = CreateDefaultTableRepository(_mockSadPathTestDbContext);

            // Act
            var result = repo.GetById(_testTableId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void DefaultTable_GetAll_ReturnsNull()
        {
            // Arrange
            var repo = CreateDefaultTableRepository(_mockSadPathTestDbContext);

            // Act
            var result = repo.GetAll();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void Object_CallDisposeInCode_InternalDisposeCalledInSadPath()
        {
            // Arrange
            var repo = CreateDefaultTableRepository(_mockSadPathTestDbContext);

            // Act
            repo.Dispose();

            // Assert
            _mockSadPathTestDbContext.Verify(x => x.Dispose());
        }

        private static DefaultTableRepository CreateDefaultTableRepository(Mock<BinderDbContext> conext)
        {
            return new DefaultTableRepository(
                conext.Object);
        }
    }
}