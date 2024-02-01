using Microsoft.EntityFrameworkCore;

namespace SampleWeb01.Infrastructure.Data
{
    internal class InMemoryDbContext: DbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options)
        : base(options)
        {
        }
    }
}
