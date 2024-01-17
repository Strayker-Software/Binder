using Binder.Core.Models.Interfaces;
using System.Text.Json.Serialization;

namespace Binder.Core.Models
{
    public record ToDoTask : IBaseEntity
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public int TableId { get; set; }
        [JsonIgnore]
        public DefaultTable Table { get; set; }

        public ToDoTask()
        {
            Name = string.Empty;
            Description = string.Empty;
            Table = new DefaultTable();
        }

        public ToDoTask(string name, string description, bool isCompleted, int tableId)
        {
            Name = name;
            Description = description;
            IsCompleted = isCompleted;
            TableId = tableId;
        }
    }
}