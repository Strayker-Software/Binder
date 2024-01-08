namespace Binder.Api.Models
{
    public class ToDoTaskDTO
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public int TableId { get; set; }

        public DefaultTableDTO? Table { get; set; }

        public ToDoTaskDTO()
        {
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}