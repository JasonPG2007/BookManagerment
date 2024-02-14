using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ObjectBusiness
{
    public class LikeComment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LikeId { get; set; }
        [Display(Name = "Comment ID")]
        public int CommentId { get; set; }
        public int Quantity { get; set; } = 0;
        public DateTime DateLike { get; set; }
        [JsonIgnore]
        public virtual Comment? Comment { get; set; }

        #region View Model
        [NotMapped]
        public string UserName { get; set; }
        #endregion
    }
}
