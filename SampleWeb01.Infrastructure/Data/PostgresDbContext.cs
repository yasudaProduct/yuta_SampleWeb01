using Microsoft.EntityFrameworkCore;

namespace SampleWeb01.Infrastructure.Data
{
    internal class PostgresDbContext : DbContext
    {
        public PostgresDbContext(DbContextOptions<PostgresDbContext> options)
        : base(options)
        {
        }
    }
}
