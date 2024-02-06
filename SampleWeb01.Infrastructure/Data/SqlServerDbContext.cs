using Microsoft.EntityFrameworkCore;
using SampleWeb01.Infrastructure.Data.Entity;

namespace SampleWeb01.Infrastructure.Data
{
    internal class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options)
        : base(options)
        {
        }
        
        public DbSet<MUser> TUser { get; set; } = default!;
        public DbSet<MUserCompany> TUserCompany { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //1対1 User = UserCompany
            modelBuilder.Entity<MUser>(entity =>
            {
                entity.HasOne(u => u.UserCompany)
                .WithOne(uc => uc.User)
                .HasForeignKey<MUserCompany>(uc => uc.UserId);
            });
        }
    }
}
