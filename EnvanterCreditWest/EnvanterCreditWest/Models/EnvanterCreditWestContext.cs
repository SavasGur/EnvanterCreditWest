using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class EnvanterCreditWestContext : DbContext
    {
        public EnvanterCreditWestContext() : base("name=EnvanterCreditWestContext")
        {
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Branches> Branches { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
