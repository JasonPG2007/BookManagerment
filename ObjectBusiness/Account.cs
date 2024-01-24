using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBusiness
{
    public class Account
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Account ID")]
        public int AccountId { get; set; }
        [Display(Name = "User ID")]
        public int UserId { get; set; }
        [Display(Name = "User name")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public virtual Decentralization? Decentralization { get; set; }
        public virtual User? User { get; set; }
    }
}
