using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBusiness
{
    public class AccessLog
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "AccessLog Id")]
        public int AccessLogId { get; set; }
        [Display(Name = "IP address")]
        public string IpAddress { get; set; }
        [Display(Name = "Visit count")]
        public int VisitCount { get; set; }
        [Display(Name = "Date access")]
        public DateTime DateAccess { get; set; }
    }
}
