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
        [JsonIgnore]
        public virtual Account? Account { get; set; }
    }
}
