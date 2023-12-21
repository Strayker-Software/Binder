using Binder.Core.Models.Interfaces;

namespace Binder.Core.Models
{
    public class AppUser : IBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Token { get; set; }

        public AppUser()
        {
            Name = string.Empty;
            Token = string.Empty;
        }
    }
}