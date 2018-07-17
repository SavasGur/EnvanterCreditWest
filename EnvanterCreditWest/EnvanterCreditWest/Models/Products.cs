using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class Products
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int Model { get; set; }
        public int Brand { get; set; }
        public int Warranty { get; set; }
        public int DateAcquired { get; set; }
        public int Barcode { get; set; }
        public int ProductionDate{ get; set; }
        public int Condition { get; set; }
        public int Price { get; set; }

    }
}