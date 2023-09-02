using Binder.Core.Models.Interfaces;

namespace Binder.Core.Models
{
    public class DefaultTable : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ToDoTask> Tasks { get; set; }

        public DefaultTable()
        {
            Name = string.Empty;
            Tasks = new List<ToDoTask>().ToArray();
        }
    }
}