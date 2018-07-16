using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class EnvanterCreditWestContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public EnvanterCreditWestContext() : base("name=EnvanterCreditWestContext")
        {
        }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Products> Products { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Branches> Branches { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Product_Details> Product_Details { get; set; }
    }
}
