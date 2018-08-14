using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class ProductModels
    {
        public int Id { get; set; }

        [DisplayName("Model")]
        public string Name { get; set; }

        public string Code { get; set; }
    }
}