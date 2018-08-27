using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class Typeys
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Code { get; set; }

        [DisplayName("Tip")]
        public string Name { get; set; }
    }

    public class TypeToModels
    {
        public int TypeId { get; set; }
        public int ModelId { get; set; }
    }
       
}