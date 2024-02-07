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
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "User ID")]
        public int UserId { get; set; }
        [Display(Name = "Full name")]
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        [RegularExpression("^0[1-9]\\d\\d{3}\\d{4}$")]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public bool Gender { get; set; } // True is male and false is female
        public DateTime DateRegister{ get; set; }
        [JsonIgnore]
        public virtual Account? Account { get; set; }
    }
}
