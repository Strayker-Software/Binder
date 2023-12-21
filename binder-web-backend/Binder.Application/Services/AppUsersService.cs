using Binder.Application.Models.Interfaces;
using Binder.Core.Models;
using Binder.Persistence.Models.Interfaces;

namespace Binder.Application.Services
{
    public class AppUsersService : IAppUsersService
    {
        private readonly IAppUsersRepository _repository;

        public AppUsersService(IAppUsersRepository usersRepository)
        {
            _repository = usersRepository;
        }

        public AppUser GetByToken(string token)
        {
            return _repository.GetByToken(token) ?? throw new ArgumentNullException();
        }
    }
}