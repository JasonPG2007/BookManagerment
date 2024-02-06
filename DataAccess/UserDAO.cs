using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDAO
    {
        private static UserDAO instance = null;
        private static readonly object Lock = new object();
        public static UserDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                    return instance;
                }
            }
        }
        public bool Login(string userName, string password)
        {
            using var context = new BookContext();
            var user = context.Accounts.SingleOrDefault(a => a.UserName.Equals(userName) && a.Password.Equals(password));
            if (user == null)
            {
                return false;
            }
            //var checkDecentralization = context.Decentralizations
            return true;
        }
    }
}
