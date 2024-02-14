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
    public class DisLikeComment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DisLikeId { get; set; }
        [Display(Name = "Comment ID")]
        public int CommentId { get; set; }
        public int Quantity { get; set; } = 0;
        public DateTime DateDisLike { get; set; }
        [JsonIgnore]
        public virtual Comment? Comment { get; set; }
    }
}
