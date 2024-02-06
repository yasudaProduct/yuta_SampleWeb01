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
        
        public DbSet<MUser> TUser { get; set; } = default!;
        public DbSet<MUserCompany> TUserCompany { get; set; } = default!;

    }
}
