using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string BranchId { get; set; }
        public int Username { get; set; }
        public string UserPassword { get; set; }
    }
}