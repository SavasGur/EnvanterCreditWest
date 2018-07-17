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
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ProductId { get; set; }
    }
}