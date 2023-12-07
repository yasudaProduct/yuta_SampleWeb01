using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merino.Data;
using Microsoft.EntityFrameworkCore;
using yuta_SampleWeb01.Models;
using yuta_SampleWeb01.ViewModels;

namespace yuta_SampleWeb01.Data
{
    public class yuta_SampleWeb01Context : DbContext
    {
        public yuta_SampleWeb01Context(DbContextOptions<yuta_SampleWeb01Context> options)
            : base(options)
        {
        }

        public DbSet<yuta_SampleWeb01.Models.Movie> Movie { get; set; } = default!;
        public DbSet<yuta_SampleWeb01.Models.TUserCompany> TUserCompany { get; set; } = default!;
        public DbSet<yuta_SampleWeb01.Models.TDataA> TDataA { get; set; } = default!;
        public DbSet<yuta_SampleWeb01.Models.TUser> TUser { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //1対1 User = UserCompany
            modelBuilder.Entity<TUser>(entity =>
            {
                entity.HasOne(u => u.UserCompany)
                .WithOne(uc => uc.User)
                .HasForeignKey<TUserCompany>(uc => uc.UserId);
            });

            //1対多 UserCompany =< DataADetail
            modelBuilder.Entity<TUserCompany>(entity =>
            {
                entity.HasMany(u => u.DataA)
                .WithOne(d => d.UserCompany)
                .HasForeignKey(d => d.userId);
            });

            //1対多 DataA =< DataADetail
            modelBuilder.Entity<TDataA>(entity =>
            {
                entity.HasMany(d => d.DataADetail)
                .WithOne(de => de.DataA)
                .HasForeignKey(de => de.DataId);
            });

        }
    }
}
