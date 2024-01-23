﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBusiness
{
    public class Decentralization
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Decentralization ID")]
        public int DecentralizationId { get; set; }
        [Display(Name = "Account ID")]
        public int AccountId { get; set; }
        [Display(Name = "Role ID")]
        public int RoleId { get; set; }
        public virtual Account? Account { get; set; }
        public virtual Role? Role { get; set; }
    }
}
