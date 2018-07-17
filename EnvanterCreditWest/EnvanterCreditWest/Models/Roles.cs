using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string Admins { get; set; }
        public string Editors { get; set; }
        public string Others { get; set; }
    }
}