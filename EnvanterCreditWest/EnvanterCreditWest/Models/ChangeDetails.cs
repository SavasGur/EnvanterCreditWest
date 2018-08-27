using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class ChangeDetails
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Changes")]
        public int ChangesId { get; set; }
        public virtual Changes Changes { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }
    }
}