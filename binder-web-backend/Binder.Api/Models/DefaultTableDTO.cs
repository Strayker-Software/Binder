namespace Binder.Api.Models
{
    public class DefaultTableDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ToDoTaskDTO>? Tasks { get; }

        public DefaultTableDTO()
        {
            Name = string.Empty;
        }
    }
}