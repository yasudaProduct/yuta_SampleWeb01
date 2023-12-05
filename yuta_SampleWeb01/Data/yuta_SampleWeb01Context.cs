using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merino.Data;
using Microsoft.EntityFrameworkCore;
using yuta_SampleWeb01.ViewModels;

namespace yuta_SampleWeb01.Data
{
    public class yuta_SampleWeb01Context : DbContext
    {
        public yuta_SampleWeb01Context (DbContextOptions<yuta_SampleWeb01Context> options)
            : base(options)
        {
        }

        public DbSet<yuta_SampleWeb01.Models.Movie> Movie { get; set; } = default!;
        public DbSet<yuta_SampleWeb01.Models.TUserCompany> TUserCompany { get; set; } = default!;
        public DbSet<yuta_SampleWeb01.Models.TDataA> TDataA { get; set; } = default!;
        public DbSet<yuta_SampleWeb01.Models.TUser> TUser { get; set; } = default!;



    }
}
