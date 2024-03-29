﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ObjectBusiness
{
    public class CategoryBook
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }
        [Display(Name = "Category name")]
        public string CategoryName { get; set; }
        public bool Set {  get; set; } // True is a set
        [Display(Name = "Date time")]
        public DateTime DateTime { get; set; } = DateTime.Now;
        [JsonIgnore]
        public virtual ICollection<Book>? Books { get; set; }
    }
}
