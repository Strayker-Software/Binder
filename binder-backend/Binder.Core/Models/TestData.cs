namespace Binder.Core.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public BaseEntity()
        {
            Name = "";
        }

        public BaseEntity(string name)
        {
            Name = name;
        }
    }
}