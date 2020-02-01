using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EMART.Models
{
    public class SellerContext:DbContext
    {
        public SellerContext(DbContextOptions<SellerContext> options) : base(options)
        {

        }
        public DbSet<Seller> Sellers { get; set; }
    }
}
