using Binder.Application.Services;
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
        }

        private DefaultTableService CreateService()
        {
            return new DefaultTableService(
                this.mockTestRepository.Object);
        }
    }
}