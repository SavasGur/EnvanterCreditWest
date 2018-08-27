using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class ProductDetails
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }



        public string Ram { get; set; }

        public string CPU { get; set; }

        public string OS { get; set; }

        public string Size { get; set; }

        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public virtual Products Products { get; set; }
    }
}