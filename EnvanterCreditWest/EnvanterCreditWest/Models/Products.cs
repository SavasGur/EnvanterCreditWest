using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Firma Adı")]
        public int FirmId { get; set; }
        [DisplayName("Cihaz")]
        public string Type { get; set; }
        public string Model { get; set; }
        [DisplayName("Marka")] 
        public string Brand { get; set; }
        [DisplayName("Garanti Bitiş Tarihi")]
        public DateTime Warranty { get; set; }
        [DisplayName("Alış Tarihi")]
        public DateTime DateAcquired { get; set; }
        [DisplayName("Barkod")]
        public int Barcode { get; set; }
        [DisplayName("Üretim Tarihi")]
        public DateTime ProductionDate{ get; set; }
        [DisplayName("Durum")]
        public bool Status { get; set; }
        [DisplayName("Fiyat")]
        public float Price { get; set; }
        [DisplayName("Şubeler")]
        public int BranchId { get; set; }

        [ForeignKey("BranchId")]
        public virtual Branches Branches { get; set; }
        [ForeignKey("FirmId")]
        public virtual Firms Firms { get; set; }
    }
}