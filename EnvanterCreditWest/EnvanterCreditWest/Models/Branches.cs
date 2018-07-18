using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class Branches
    {
        public int Id { get; set; }
        public string BranchName { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public int ProductId { get; set; }
    }
}