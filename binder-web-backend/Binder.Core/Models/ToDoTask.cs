using Binder.Core.Models.Interfaces;

namespace Binder.Core.Models
{
    public class ToDoTask : IBaseEntity
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public ToDoTask()
        {
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}