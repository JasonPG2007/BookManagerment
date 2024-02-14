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
    public class Event
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Event ID")]
        public int EventId { get; set; }
        [Display(Name = "Category event")]
        public int CategoryId { get; set; }
        [Display(Name = "Account ID")]
        public int AccountId { get; set; }
        [Display(Name = "Event name")]
        public string EventName { get; set; }
        [Display(Name = "Event description")]
        public string EventDescription { get; set; }
        [Display(Name = "Content")]
        public string EventContent { get; set; }
        public string? Picture { get; set; }
        [Display(Name = "Number of participants")]
        public int NumberOfParticipants { get; set; } = 0; // If = 0 then there is no limit to participants
        [Display(Name = "Date created")]
        public DateTime DateCreated { get; set; }
        [JsonIgnore]
        public virtual Account? Account { get; set; }
        [JsonIgnore]
        public virtual EventCategory? Category { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<RegisterJoinEvent>? RegisterJoinEvents { get; set; }
        [NotMapped]
        public IFormFile ImagesEvent { get; set; }

        #region View Model
        [NotMapped]
        public string? Avatar { get; set; }
        [NotMapped]
        public string? Content { get; set; }
        [NotMapped]
        [Display(Name = "User name")]
        public string? UserName { get; set; }
        [NotMapped]
        public string? Address { get; set; }
        [NotMapped]
        public string? City { get; set; }
        [NotMapped]
        public string? Region { get; set; }
        #endregion
    }
}
