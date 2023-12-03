using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Merino.Data
{
    public class MerinoDbContext : DbContext
    {
        public MerinoDbContext (DbContextOptions<MerinoDbContext> options)
            : base(options)
        {
        }

    }
}
