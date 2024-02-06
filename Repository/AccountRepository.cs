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
        public void DeleteAccount(int id) => AccountDAO.Instance.DeleteAccount(id);
    }
}
