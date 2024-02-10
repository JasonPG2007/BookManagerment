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
    public class RegisterJoinEvent
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegisterId { get; set; }
        //[Display(Name = "Event ID")]
        //public int EventId { get; set; }
        //[Display(Name = "Account ID")]
        //public int AccountId { get; set; }
        //[JsonIgnore]
        //public virtual Account? Account { get; set; }
        //[JsonIgnore]
        //public virtual Event? Event { get; set; }
    }
}
