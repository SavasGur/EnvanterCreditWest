using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class Firms
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, DisplayName("Firma Adı")]
        public string Name { get; set; }

        [Required, DisplayName("Telefon Numarası")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        [DisplayName("Adres")]
        public string Address { get; set; }

        [DisplayName("Satış Temsilcisi")]
        public string VendorName { get; set; }

        [DisplayName("Temsilci Email")]
        public string VendorEmail { get; set; }

        [DisplayName("Temsilci Numarası")]
        public string VendorNumber { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }
    }
}