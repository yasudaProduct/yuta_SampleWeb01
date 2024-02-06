using Microsoft.EntityFrameworkCore;
using SampleWeb01.Infrastructure.Data.Entity;

namespace SampleWeb01.Infrastructure.Data
{
    internal class PostgresDbContext : DbContext
    {
        public PostgresDbContext(DbContextOptions<PostgresDbContext> options)
        : base(options)
        {
        }
        
        public DbSet<TUser> TUser { get; set; } = default!;
        public DbSet<TUserCompany> TUserCompany { get; set; } = default!;

    }
}
