using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class Changes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Tarih")]
        public DateTime? Date { get; set;  }
      
        public string Ip { get; set; }

        public string LocalIpAddress { get; set; }

        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public virtual Products Products { get; set; }
    }
}