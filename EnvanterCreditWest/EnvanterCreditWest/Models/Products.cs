using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FirmId { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public DateTime Warranty { get; set; }
        public DateTime DateAcquired { get; set; }
        public int Barcode { get; set; }
        public DateTime ProductionDate{ get; set; }
        public bool Status { get; set; }
        public float Price { get; set; }
        public int BranchId { get; set; }

        [ForeignKey("BranchId")]
        public virtual Branches Branches { get; set; }

        [ForeignKey("FirmId")]
        public virtual Firms Firms { get; set; }
    }
}