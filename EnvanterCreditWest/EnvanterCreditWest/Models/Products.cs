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
        [DisplayName("ID"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Barkod")]
        public string Barcode { get; set; }

        public string IP { get; set; }

        public string Gateway { get; set; }

        [DisplayName("Cihaz Adı")]
        public string CihazAdi { get; set; }

        public string BarcodeUrl { get; set; }

        [DisplayName("Alış Tarihi")]
        public DateTime DateAcquired { get; set; }

        [DisplayName("Garanti Bitiş Tarihi")]
        public DateTime Warranty { get; set; }

        [DisplayName("Fiyat")]
        public float Price { get; set; }

        [DisplayName("Kur")]
        public int Currency { get; set; }

        public string InvoiceURL { get; set; }

        #region ForeignKey
        
        [Required,DisplayName("Türü"), ForeignKey("Types")]
        public int TypeId { get; set; }
        public virtual Typeys Types { get; set; }


        [Required, DisplayName("Model"), ForeignKey("ProductModels")]
        public int ProductModelId { get; set; }
        public virtual ProductModels ProductModels { get; set; }


        [Required,ForeignKey("Branches"), DisplayName("Şube")]
        public int BranchId { get; set; }
        public virtual Branches Branches { get; set; }


        [Required,ForeignKey("Statuses"), DisplayName("Durum")]
        public int StatusId { get; set; }
        public virtual Statuses Statuses { get; set; }


        [Required,ForeignKey("Brands"), DisplayName("Marka")]
        public int BrandId { get; set; }
        public virtual Brands Brands { get; set; }


        [Required,ForeignKey("Users")]
        public int? UserId { get; set; }
        public virtual Users Users { get; set; }

        [Required, ForeignKey("Firms"), DisplayName("Firma Adı")]
        public int FirmId { get; set; }
        public virtual Firms Firms { get; set; }
        #endregion
    }
}

