using Binder.Core.Models.Interfaces;

namespace Binder.Core.Models
{
    public class AppVersion : IBaseEntity
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public uint Major { get; set; }
        public uint Minor { get; set; }
        public uint Patch { get; set; }

        public AppVersion()
        {
            Name = string.Empty;
            Major = 0;
            Minor = 0;
            Patch = 0;
        }
    }
}