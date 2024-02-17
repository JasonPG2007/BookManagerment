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
    public class Feedback
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Feedback ID")]
        public int FeedbackId { get; set; }
        [Display(Name = "Account ID")]
        public int AccountId { get; set; }
        [Display(Name = "Service ID")]
        public int ServiceId { get; set; }
        public int Evaluate { get; set; } // Max 10 star, Min 1 star
        public string? Content { get; set; }
        [Display(Name = "Date feedback")]
        public DateTime DateFeedBack { get; set; }
        [JsonIgnore]
        public virtual Account? Account { get; set; }
        [JsonIgnore]
        public virtual Service? Service { get; set; }
    }
}
