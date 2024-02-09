using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBusiness
{
    public class EventViewModel
    {
        [Display(Name = "Event ID")]
        public int EventId { get; set; }
        [Display(Name = "Category ID")]
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
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }
}
