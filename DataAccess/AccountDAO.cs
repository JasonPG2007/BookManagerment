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

        #region GetAccountByUserName function
        public Account GetAccountByUserName(string username)
        {
            using var context = new BookContext();
            var checkAccountContains = context.Accounts.FirstOrDefault(a => a.UserName == username);
            return checkAccountContains;
        }
        #endregion

        #region GetUserName function
        public bool GetUserName(string userName)
        {
            using var context = new BookContext();
            var user = context.Accounts.FirstOrDefault(a => a.UserName.Equals(userName));
            if (user != null)
            {
                return true;
            }
            return false;
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

        #region ResetPassword function
        public bool ResetPassword(string userName, string newPassword)
        {
            using var context = new BookContext();
            var checkAccountContains = GetAccountByUserName(userName);
            int check = 0;
            if (checkAccountContains != null)
            {
                checkAccountContains.Password = newPassword;
                try
                {
                    context.Entry<Account>(checkAccountContains).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    check = context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            if (check > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
