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

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Branches> Branches { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Roles> Roles { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Users> Users { get; set; }
    }
}
