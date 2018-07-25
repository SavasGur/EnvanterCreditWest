using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class UserProducts
    {
        public int Id { get; set; }
        [DisplayName("Cihaz")]
        public int ProductId { get; set; }
        [DisplayName("Kullanıcı")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }
        [ForeignKey("ProductId")]
        public virtual Products Product { get; set; }
    }
}