﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class ChangeDetails
    {
        public int Id { get; set; }

        public int ChangesId { get; set; }

        [ForeignKey("ChangesId")]
        public virtual Changes Changes { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }
    }
}