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
    public class Service
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Service ID")]
        public int ServiceId { get; set; }
        [Display(Name = "Service name")]
        public string? ServiceName { get; set; }
        [Display(Name = "Other service")]
        public string? OtherNameService { get; set; }
        [Display(Name = "Date create")]
        public DateTime DateTime { get; set; }
        [JsonIgnore]
        public virtual ICollection<Feedback>? Feedbacks { get; set; }
    }
}
