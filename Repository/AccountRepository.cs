using DataAccess;
using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository : IAccountRepository
    {
        public void UpdateAccount(Account account) => AccountDAO.Instance.UpdateAccount(account);
        public Account GetAccountById(int id) => AccountDAO.Instance.GetAccountById(id);
        public Account GetAccountByUserName(string username) => AccountDAO.Instance.GetAccountByUserName(username);
        public void DeleteAccount(int id) => AccountDAO.Instance.DeleteAccount(id);
        public bool GetUserName(string userName) => AccountDAO.Instance.GetUserName(userName);
        public bool ResetPassword(string userName, string newPassword) => AccountDAO.Instance.ResetPassword(userName, newPassword);
    }
}
