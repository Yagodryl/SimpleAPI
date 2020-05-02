using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkaBack.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace LinkaBack.DAL
{
    public class EFDbContext :DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
