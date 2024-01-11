using Binder.Application.Services;
using Binder.Application.Services.Middleware.CustomExceptions;
using Binder.Core.Constants;
using Binder.Core.Models;
using Binder.Persistence.Models.Interfaces;

namespace Binder.UnitTests.Services
{
    public sealed class DefaultTableServiceTests
    {
        private readonly MockRepository _mockRepository;
        private readonly Mock<IDefaultTableRepository> _mockDefaultTableRepository;
        private readonly Mock<IDefaultTableRepository> _mockDefaultTableRepositorySadPath;
        private readonly Mock<IToDoTasksRepository> _mockToDoTasksRepository;
        private readonly DefaultTable _testTableData = new() { Id = 1, Name = "Test" };
        private readonly ToDoTask _testTaskDataOne = new() { Name = "One", TableId = 1 };
        private readonly ToDoTask _testTaskDataTwo = new() { Name = "Two", TableId = 2 };
        private readonly ToDoTask _testTaskDataThree = new() { Name = "Three", TableId = 1 };
        private readonly List<DefaultTable> _testTableList = new();
        private readonly List<ToDoTask> _testTasksList;
        private const int _testTableId = 1;
        private const int _testTableIdSadPath = 0;

        public DefaultTableServiceTests()
        {
            _testTableList.Add(_testTableData);
            _testTaskDataOne.Table = _testTableData;
            _testTaskDataTwo.Table = _testTableData;
            _testTaskDataThree.Table = _testTableData;
            _testTasksList = new()
            {
                _testTaskDataOne,
                _testTaskDataTwo,
                _testTaskDataThree
            };

            _mockRepository = new MockRepository(MockBehavior.Strict);

            _mockDefaultTableRepository = _mockRepository.Create<IDefaultTableRepository>();
            _mockDefaultTableRepository.Setup(x => x.GetById(It.Is<int>(x => x == _testTableId))).Returns(_testTableData);
            _mockDefaultTableRepository.Setup(x => x.GetById(It.Is<int>(x => x != _testTableId)))
                .Returns((DefaultTable)null!);
            _mockDefaultTableRepository.Setup(x => x.GetAll()).Returns(_testTableList);

            _mockDefaultTableRepositorySadPath = _mockRepository.Create<IDefaultTableRepository>();
            _mockDefaultTableRepositorySadPath.Setup(x => x.GetById(It.IsAny<int>())).Returns((DefaultTable)null!);
            _mockDefaultTableRepositorySadPath.Setup(x => x.GetAll()).Returns((ICollection<DefaultTable>)null!);

            _mockToDoTasksRepository = _mockRepository.Create<IToDoTasksRepository>();
            _mockToDoTasksRepository.Setup(x => x.GetTasksByTable(It.Is<int>(x => x == _testTableId))).Returns(_testTasksList);
        }

        [Fact]
        public void DefaultTable_GetTableByTableId_ReturnsCorrectTableData()
        {
            // Arrange
            var service = CreateService(_mockDefaultTableRepository, _mockToDoTasksRepository);

            // Act
            var result = service.GetTable(_testTableId);

            // Assert
            result.Should().BeSameAs(_testTableData);
        }

        [Fact]
        public void DefaultTable_GetTableByTableId_ThrowsNotFoundException()
        {
            // Arrange
            var service = CreateService(_mockDefaultTableRepository, _mockToDoTasksRepository);

            // Act
            var exception = Record.Exception(() => service.GetTable(_testTableIdSadPath));

            // Assert
            exception.Should()
                .BeOfType(typeof(NotFoundException))
                .And.Subject.As<Exception>().Message.Should()
                .BeEquivalentTo(ExceptionConstants.ResourceNotFoundMessage);
        }

        [Fact]
        public void DefaultTable_GetAllTables_ReturnsCorrectTableData()
        {
            // Arrange
            var service = CreateService(_mockDefaultTableRepository, _mockToDoTasksRepository);

            // Act
            var result = service.GetAllTables();

            // Assert
            result.Should().BeEquivalentTo(_testTableList);
        }

        [Fact]
        public void DefaultTable_GetAllTables_ThrowsNotFoundException()
        {
            // Arrange
            var service = CreateService(_mockDefaultTableRepositorySadPath, _mockToDoTasksRepository);

            // Act
            var exception = Record.Exception(() => service.GetAllTables());

            // Assert
            exception.Should()
                .BeOfType(typeof(NotFoundException))
                .And.Subject.As<Exception>().Message.Should()
                .BeEquivalentTo(ExceptionConstants.ResourceNotFoundMessage);
        }

        private static DefaultTableService CreateService(
            Mock<IDefaultTableRepository> tableRepostiory,
            Mock<IToDoTasksRepository> tasksRepository)
        {
            return new DefaultTableService(
                tableRepostiory.Object,
                tasksRepository.Object);
        }
    }
}