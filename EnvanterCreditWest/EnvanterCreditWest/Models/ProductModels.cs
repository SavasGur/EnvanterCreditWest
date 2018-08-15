using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int TypeId { get; set; }
    }
}