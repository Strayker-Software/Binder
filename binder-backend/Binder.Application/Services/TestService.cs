using Binder.Application.Models.Interfaces;
using Binder.Infrastructure.Models.Interfaces;

namespace Binder.Application.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _repository;

        public TestService(ITestRepository repository)
        {
            _repository = repository;
        }

        public string GetFirstEntityName()
        {
            var data = _repository.GetBaseEntities().ToArray();

            return data[0].Name;
        }
    }
}