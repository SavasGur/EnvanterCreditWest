using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class Brands
    {
        public int Id { get; set; }
        public string Code { get; set; }

        [DisplayName("Marka")]
        public string BrandName { get; set; }
    }
}