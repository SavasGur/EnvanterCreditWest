using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public DateTime WarrantyEnd { get; set; }
        public DateTime DateAcquired { get; set; }
        public int Barcode { get; set; }
        public DateTime ProductionDate { get; set; }
        public string Condition { get; set; }
        public int Price { get; set; }
    }
}