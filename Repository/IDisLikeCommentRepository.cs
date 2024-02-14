using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IDisLikeCommentRepository
    {
        public IEnumerable<DisLikeComment> GetDisLikes();
        public DisLikeComment GetDisLikeById(int id);
        public bool InsertDisLike(DisLikeComment disLike);
        public bool UpdateDisLike(DisLikeComment disLike);
        public bool DeleteDisLike(int id);
    }
}
