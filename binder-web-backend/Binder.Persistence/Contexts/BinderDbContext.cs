using Binder.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Binder.Persistence.Contexts
{
    public class BinderDbContext : DbContext
    {
        public virtual DbSet<DefaultTable> Tables { get; set; }
        public virtual DbSet<ToDoTask> ToDoTasks { get; set; }
        public virtual DbSet<AppVersion> AppVersions { get; set; }

        public BinderDbContext()
        {
        }

        public BinderDbContext(DbContextOptions<BinderDbContext> contextOptions)
            : base(contextOptions)
        {
        }
    }
}