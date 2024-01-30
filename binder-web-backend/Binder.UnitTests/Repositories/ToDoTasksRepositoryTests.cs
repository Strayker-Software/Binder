using Binder.Core.Models;
using Binder.Persistence.Contexts;
using Binder.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq.EntityFrameworkCore;

namespace Binder.UnitTests.Repositories
{
    public sealed class ToDoTasksRepositoryTests
    {
        private readonly MockRepository _mockRepository;
        private readonly Mock<BinderDbContext> _mockHappyPathTestDbContext;
        private readonly Mock<BinderDbContext> _mockSadPathTestDbContext;
        private readonly DefaultTable _testDefaultTableOne = new() { Id = 1 };
        private readonly DefaultTable _testDefaultTableTwo = new() { Id = 2 };
        private readonly ToDoTask _testTaskDataOne = new() { Name = "One", TableId = 1 };
        private readonly ToDoTask _testTaskDataTwo = new() { Name = "Two", TableId = 2 };
        private readonly ToDoTask _testTaskDataThree = new() { Name = "Three", TableId = 1 };
        private readonly List<DefaultTable> _testTableListData;
        private readonly List<ToDoTask> _testTasksListTableOneData;
        private const int _testTableId = 1;

        public ToDoTasksRepositoryTests()
        {
            _testTaskDataOne.Table = _testDefaultTableOne;
            _testTaskDataTwo.Table = _testDefaultTableTwo;
            _testTaskDataThree.Table = _testDefaultTableOne;
            _testTableListData = new List<DefaultTable>()
            {
                _testDefaultTableOne,
                _testDefaultTableTwo
            };
            _testTasksListTableOneData = new List<ToDoTask>()
            {
                _testTaskDataOne,
                _testTaskDataThree
            };

            _mockRepository = new MockRepository(MockBehavior.Strict);

            _mockHappyPathTestDbContext = _mockRepository.Create<BinderDbContext>();
            _mockHappyPathTestDbContext = _mockRepository.Create<BinderDbContext>();
            _mockHappyPathTestDbContext.SetupSet(x => x.Tables = It.IsAny<DbSet<DefaultTable>>()).CallBase();
            _mockHappyPathTestDbContext.SetupGet(x => x.Tables).ReturnsDbSet(_testTableListData);
            _mockHappyPathTestDbContext.SetupSet(x => x.ToDoTasks = It.IsAny<DbSet<ToDoTask>>()).CallBase();
            _mockHappyPathTestDbContext.SetupGet(x => x.ToDoTasks).ReturnsDbSet(_testTasksListTableOneData);
            _mockHappyPathTestDbContext.Setup(x => x.Dispose()).Verifiable();

            _mockSadPathTestDbContext = _mockRepository.Create<BinderDbContext>();
            _mockSadPathTestDbContext.SetupSet(x => x.Tables = It.IsAny<DbSet<DefaultTable>>()).CallBase();
            _mockSadPathTestDbContext.SetupGet(x => x.Tables).ReturnsDbSet(new List<DefaultTable>());
            _mockSadPathTestDbContext.SetupSet(x => x.ToDoTasks = It.IsAny<DbSet<ToDoTask>>()).CallBase();
            _mockSadPathTestDbContext.SetupGet(x => x.ToDoTasks).ReturnsDbSet(new List<ToDoTask>());
            _mockSadPathTestDbContext.Setup(x => x.Dispose()).Verifiable();
        }

        [Fact]
        public void ToDoTasks_GetByTableId_ReturnsCorrectTasksData()
        {
            // Arrange
            var toDoTasksRepository = CreateToDoTasksRepository(_mockHappyPathTestDbContext);

            // Act
            var result = toDoTasksRepository.GetTasksByTable(_testTableId);

            // Assert
            result.Should().BeEquivalentTo(_testTasksListTableOneData);
        }

        [Fact]
        public void ToDoTasks_GetByTableId_ReturnsNull()
        {
            // Arrange
            var toDoTasksRepository = CreateToDoTasksRepository(_mockSadPathTestDbContext);

            // Act
            var result = toDoTasksRepository.GetTasksByTable(_testTableId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void Object_CallDisposeInCode_InternalDisposeCalledInHappyPath()
        {
            // Arrange
            var toDoTasksRepository = CreateToDoTasksRepository(_mockHappyPathTestDbContext);

            // Act
            toDoTasksRepository.Dispose();

            // Assert
            _mockHappyPathTestDbContext.Verify(x => x.Dispose());
        }

        [Fact]
        public void Object_CallDisposeInCode_InternalDisposeCalledInSadPath()
        {
            // Arrange
            var toDoTasksRepository = CreateToDoTasksRepository(_mockSadPathTestDbContext);

            // Act
            toDoTasksRepository.Dispose();

            // Assert
            _mockSadPathTestDbContext.Verify(x => x.Dispose());
        }

        private static ToDoTasksRepository CreateToDoTasksRepository(Mock<BinderDbContext> context)
        {
            return new ToDoTasksRepository(
                context.Object);
        }
    }
}