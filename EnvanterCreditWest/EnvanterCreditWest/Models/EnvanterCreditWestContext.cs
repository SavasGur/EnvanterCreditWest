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
        public DbSet<Users> Users { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Changes> Changes { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Firms> Firms { get; set; }
    }
}
