﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ObjectBusiness
{
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Comment ID")]
        public int CommentId { get; set; }
        [Display(Name = "Event ID")]
        public int EventId { get; set; }
        public string Content { get; set; }
        public int Interact { get; set; } = 0;
        [Display(Name = "Date comment")]
        public DateTime DateComment { get; set; }
        [JsonIgnore]
        public virtual Event? Event { get; set; }
        [JsonIgnore]
        public virtual ICollection<LikeComment>? LikeComments { get; set; }
        [JsonIgnore]
        public virtual ICollection<DisLikeComment>? DisLikeComments { get; set; }


        #region View Model
        [NotMapped]
        public string UserName { get; set; }
        [NotMapped]
        public string Picture { get; set; }
        [NotMapped]
        [Display(Name = "Account ID")]
        public int AccountId { get; set; }
        [NotMapped]
        public int Like {  get; set; }
        [NotMapped]
        public int DisLike { get; set; }
        #endregion
    }
}
