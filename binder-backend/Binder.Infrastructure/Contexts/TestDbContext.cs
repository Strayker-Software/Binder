using Binder.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Binder.Infrastructure.Contexts
{
    public class TestDbContext : DbContext
    {
        public DbSet<BaseEntity> BaseEntities { get; set; }

        public TestDbContext(DbContextOptions<TestDbContext> contextOptions)
            : base(contextOptions)
        {
        }
    }
}