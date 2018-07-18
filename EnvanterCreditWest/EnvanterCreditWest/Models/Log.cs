using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class Log
    {
        public int LogId { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public int TakenId { get; set; }
        public int GivenId { get; set; }
        public int BranchId { get; set; }
        public string Description { get; set; }
    }
}