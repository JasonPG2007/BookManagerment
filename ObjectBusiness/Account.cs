using Microsoft.AspNetCore.Http;
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
        public int Star { get; set; } = 0; // Users rate by number of stars
        public float Point { get; set; } = 0;
        public DateTime DateCreated { get; set; }
        [JsonIgnore]
        public virtual Decentralization? Decentralization { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
        [JsonIgnore]
        public virtual ICollection<RegisterJoinEvent>? RegisterJoinEvents { get; set; }
        [JsonIgnore]
        public virtual ICollection<Feedback>? Feedbacks { get; set; }
        [NotMapped]
        public IFormFile AvatarImages { get; set; }

        #region View Model
        [JsonIgnore]
        [NotMapped]
        [Display(Name = "Full name")]
        public string FullName { get; set; }
        [JsonIgnore]
        [NotMapped]
        public int Age { get; set; }
        [JsonIgnore]
        [NotMapped]
        public string Address { get; set; }
        [JsonIgnore]
        [NotMapped]
        public string Email { get; set; }
        [JsonIgnore]
        [NotMapped]
        [RegularExpression("^0[1-9]\\d\\d{3}\\d{4}$")]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        [JsonIgnore]
        [NotMapped]
        public string City { get; set; }
        [JsonIgnore]
        [NotMapped]
        public string Region { get; set; }
        [JsonIgnore]
        [NotMapped]
        public bool Gender { get; set; } // True is male and false is female
        [JsonIgnore]
        [NotMapped]
        public string? Picture { get; set; }
        [JsonIgnore]
        [NotMapped]
        public DateTime DateRegister { get; set; }
        #endregion
    }
}
