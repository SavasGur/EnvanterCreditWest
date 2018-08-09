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

        [DisplayName("Cihaz")]
        [Required]
        public string Type { get; set; }

        [DisplayName("Marka")]
        [Required]
        public int BrandId { get; set; }
        [DisplayName("Model")]
        [Required]
        public string Model { get; set; }

        [DisplayName("Barkod")]
        public int Barcode { get; set; }

        [Required]
        [DisplayName("Şube")]
        public int BranchId { get; set; }

        public int? UserId { get; set; }

        [DisplayName("Alış Tarihi")]
        public DateTime DateAcquired { get; set; }

        [DisplayName("Garanti Bitiş Tarihi")]
        public DateTime Warranty { get; set; }

        [DisplayName("Firma Adı")]
        public int FirmId { get; set; }

        [DisplayName("Kullanılıyor/Kullanılmıyor")]
        [Required]
        public bool Status { get; set; }

        [DisplayName("Fiyat")]
        public float Price { get; set; }

        public string InvoiceURL { get; set; }





        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brands Brands { get; set; }

        [ForeignKey("BranchId")]
        public virtual Branches Branches { get; set; }

        [ForeignKey("FirmId")]
        public virtual Firms Firms { get; set; }
    }
}