using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAccountRepository
    {
        public bool UpdateAccount(Account account);
        public Account GetAccountById(int id);
        public Account GetAccountByUserName(string username);
        public void DeleteAccount(int id);
        public bool GetUserName(string userName);
        public bool ResetPassword(string userName, string newPassword);
        public IEnumerable<Account> GetUserByIdAccount(int id);
        public IEnumerable<Account> GetAccount();
    }
}
