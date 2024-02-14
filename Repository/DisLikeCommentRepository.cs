using DataAccess;
using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DisLikeCommentRepository : IDisLikeCommentRepository
    {
        public bool DeleteDisLike(int id) => DisLikeCommentDAO.Instance.DeleteDisLike(id);

        public DisLikeComment GetDisLikeById(int id) => DisLikeCommentDAO.Instance.GetDisLikeById(id);

        public IEnumerable<DisLikeComment> GetDisLikes() => DisLikeCommentDAO.Instance.GetDisLikes();

        public bool InsertDisLike(DisLikeComment disLike) => DisLikeCommentDAO.Instance.InsertDisLike(disLike);

        public bool UpdateDisLike(DisLikeComment disLike) => DisLikeCommentDAO.Instance.UpdateDisLike(disLike);
    }
}
