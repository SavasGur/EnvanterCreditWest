using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class Statuses
    {
        public int Id {get;set;}
        [DisplayName("Durum")]
        public string Name { get; set; }
    }
}