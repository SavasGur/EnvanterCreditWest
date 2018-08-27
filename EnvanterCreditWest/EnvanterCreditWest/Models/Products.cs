﻿using System;
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

        [Required]
        [DisplayName("Marka")]
        public int BrandId { get; set; }

        [DisplayName("Model")]
        public int ProductModelId { get; set; }

        [DisplayName("Barkod")]
        public string Barcode { get; set; }

        public string IP { get; set; }

        public string Gateway { get; set; }

        [DisplayName("Cihaz Adı")]
        public string CihazAdi { get; set; }

        public string BarcodeUrl { get; set; }

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

        [Required]
        [DisplayName("Durum")]
        public int StatusId { get; set; }

        [DisplayName("Fiyat")]
        public float Price { get; set; }

        [DisplayName("Kur")]
        public int Currency { get; set; }

        public string InvoiceURL { get; set; }

        [ForeignKey("ProductModelId")]
        public virtual ProductModels ProductModels { get; set; }

        [DisplayName("Türü")]
        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        public virtual Typeys Types { get; set; }

        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brands Brands { get; set; }

        [ForeignKey("BranchId")]
        public virtual Branches Branches { get; set; }

        [ForeignKey("StatusId")]
        public virtual Statuses Statuses { get; set; }

        [ForeignKey("FirmId")]
        public virtual Firms Firms { get; set; }
    }
}

