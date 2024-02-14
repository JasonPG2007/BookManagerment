using DataAccess;
using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class LikeCommentRepository : ILikeCommentRepository
    {
        public bool DeleteLike(int id) => LikeCommentDAO.Instance.DeleteLike(id);

        public LikeComment GetLikeById(int id) => LikeCommentDAO.Instance.GetLikeById(id);

        public IEnumerable<LikeComment> GetLikes() => LikeCommentDAO.Instance.GetLikes();

        public bool InsertLike(LikeComment like) => LikeCommentDAO.Instance.InsertLike(like);

        public bool UpdateLike(LikeComment like) => LikeCommentDAO.Instance.UpdateLike(like);
        public IEnumerable<LikeComment> GetAcountLike(int idAccount) => LikeCommentDAO.Instance.GetAcountLike(idAccount);
    }
}
