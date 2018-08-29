using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class DbEntity : DbContext
    {
        public DbSet<tblUser> tblUsers { get; set; }
    }
}