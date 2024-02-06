using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        public string Login(string userName, string password) => UserDAO.Instance.Login(userName, password);
    }
}
