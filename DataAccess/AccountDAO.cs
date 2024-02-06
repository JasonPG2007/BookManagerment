using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        private static readonly object Lock = new object();
        public static AccountDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }
            }
        }

        #region GetAccountById function
        public Account GetAccountById(int id)
        {
            using var context = new BookContext();
            var checkAccountContains = context.Accounts.FirstOrDefault(a => a.AccountId == id);
            return checkAccountContains;
        }
        #endregion

        #region UpdateAccount function
        public void UpdateAccount(Account account)
        {
            using var context = new BookContext();
            try
            {
                var checkAccountContains = GetAccountById(account.AccountId);
                if (checkAccountContains != null)
                {
                    context.Entry<Account>(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region DeleteAccount function
        public void DeleteAccount(int id)
        {
            using var context = new BookContext();
            try
            {
                var checkAccountContains = GetAccountById(id);
                if (checkAccountContains != null)
                {
                    context.Accounts.Remove(checkAccountContains);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
