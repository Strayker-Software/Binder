namespace Binder.Core.Models.Interfaces
{
    public interface IBaseEntity
    {
        int Id { get; }

        string Name { get; set; }
    }
}