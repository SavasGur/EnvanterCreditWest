﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;

namespace EnvanterCreditWest.Models
{
    public class Branches
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, DisplayName("Şube Adı")]
        public string BranchName { get; set; }

        public string Adres { get; set; }

    }
    
}