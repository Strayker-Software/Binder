using Binder.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Binder.Infrastructure.Contexts
{
    public class BinderDbContext : DbContext
    {
        public virtual DbSet<DefaultTable> Tables { get; set; }
        public virtual DbSet<ToDoTask> ToDoTasks { get; set; }

        public BinderDbContext()
        {
        }

        public BinderDbContext(DbContextOptions<BinderDbContext> contextOptions)
            : base(contextOptions)
        {
        }
    }
}