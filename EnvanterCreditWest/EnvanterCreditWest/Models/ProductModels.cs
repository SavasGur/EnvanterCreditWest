using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class ProductModels
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Model")]
        public string Name { get; set; }
        [DisplayName("Kod")]
        public string Code { get; set; }
        [DisplayName("Tip")]
        public int TypeId { get; set; }
    }
}