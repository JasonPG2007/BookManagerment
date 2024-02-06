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
        public string Login(string userName, string password)
        {
            using var context = new BookContext();
            var user = context.Accounts.SingleOrDefault(a => a.UserName.Equals(userName) && a.Password.Equals(password));
            if (user == null)
            {
                return "This account does not exist.";
            }
            var checkDecentralization = from a in context.Decentralizations
                                        join b in context.Roles
                                        on a.RoleId equals b.RoleId
                                        join c in context.Accounts
                                        on a.AccountId equals c.AccountId
                                        where c.AccountId.Equals(user.AccountId)
                                        select new Decentralization
                                        {
                                            RoleName = b.RoleName,
                                            UserName = c.UserName
                                        };
            var result = "";
            foreach (var check in checkDecentralization)
            {
                result = check.RoleName;
            }
            return result;
        }
    }
}
