using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }


    public class Branches
    {
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ProductId { get; set; }

    }

    public class ProductDetails
    {
        public int Id { get; set; }
        public string Ram { get; set; }
        public string CPU { get; set; }
        public string OS { get; set; }
        public string Size { get; set; }

    }

    public class Roles
    {
        public int Id { get; set; }
        public string Admins { get; set; }
        public string Editors { get; set; }
        public string Others { get; set; }
    }

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