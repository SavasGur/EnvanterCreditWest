using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class Users
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required,DisplayName("İsim Soyisim")]
        public string FirstLastName { get; set; }

        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }

        [DisplayName("Şifre")]
        public string Password { get; set; }

        public bool Admin { get; set; }
    }
}