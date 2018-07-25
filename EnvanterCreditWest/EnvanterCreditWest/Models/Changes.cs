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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Tarih")]
        public DateTime Date { get; set; }
        public int ChangesDetailsId { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        public string IP { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Products Products { get; set; }

        [ForeignKey("ChangesDetailsId")]
        public virtual ChangeDetails ChangeDetails { get; set; }
    }
}