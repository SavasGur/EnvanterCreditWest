using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;

namespace EnvanterCreditWest.Models
{
    public class Branches
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Şube Adı")]
        [Required]
        public string BranchName { get; set; }

        [DisplayName("Enlem")]
        public string Latitude { get; set; }

        [DisplayName("Boylam")]
        public string Longitude { get; set; }
    }
    
}