using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ObjectBusiness
{
    public class EventCategory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }
        [Display(Name = "Category name")]
        public string CategoryName { get; set; }
        [Display(Name = "Category ID")]
        public string? CategoryDescription { get; set; }
        [Display(Name = "Date created")]
        public DateTime DateCreated { get; set; }
        [JsonIgnore]
        public virtual ICollection<Event>? Events { get; set; }
    }
}
