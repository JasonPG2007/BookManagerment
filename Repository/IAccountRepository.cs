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
        public void UpdateAccount(Account account);
        public Account GetAccountById(int id);
        public void DeleteAccount(int id);
    }
}
