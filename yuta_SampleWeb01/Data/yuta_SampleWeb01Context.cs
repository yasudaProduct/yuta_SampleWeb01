using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using yuta_SampleWeb01.Models;

namespace yuta_SampleWeb01.Data
{
    public class yuta_SampleWeb01Context : DbContext
    {
        public yuta_SampleWeb01Context (DbContextOptions<yuta_SampleWeb01Context> options)
            : base(options)
        {
        }

        public DbSet<yuta_SampleWeb01.Models.Movie> Movie { get; set; } = default!;
        public DbSet<yuta_SampleWeb01.Entity.TUserCompany> TUserCompany { get; set; } = default!;
        
    }
}
