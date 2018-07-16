using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class Product_Details
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public string RAM { get; set; }
        public string MAC { get; set; }
        public string PcType { get; set; }
        public string CPU { get; set; }
        public string OS { get; set; }
        public string Storage { get; set; }
        public string Size { get; set; }
        public string Resolution { get; set; }
        public int ProductId { get; set; }
    }
}