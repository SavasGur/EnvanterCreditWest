﻿using System;
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

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Branches> Branches { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Users> Users { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.ChangeDetails> ChangeDetails { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Firms> Firms { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Products> Products { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Changes> Changes { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.ProductDetails> ProductDetails { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.UserProducts> UserProducts { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Typeys> Types { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Brands> Brands { get; set; }
    }
}
