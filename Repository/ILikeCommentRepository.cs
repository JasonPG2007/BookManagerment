using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ILikeCommentRepository
    {
        public IEnumerable<LikeComment> GetLikes();
        public LikeComment GetLikeById(int id);
        public bool InsertLike(LikeComment like);
        public bool UpdateLike(LikeComment like);
        public bool DeleteLike(int id);
        public IEnumerable<LikeComment> GetAcountLike(int idAccount);
    }
}
