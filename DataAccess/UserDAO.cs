using Microsoft.EntityFrameworkCore;
using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// @author Jason PG
    /// </summary>
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

        #region GetUsers function
        public IEnumerable<User> GetUsers()
        {
            using var context = new BookContext();
            var listUser = context.Users.ToList();
            return listUser;
        }
        #endregion

        #region Login function
        public string Login(string userName, string password)
        {
            using var context = new BookContext();
            var user = context.Accounts.SingleOrDefault(a => a.UserName.Equals(userName) && a.Password.Equals(password));
            if (user == null)
            {
                return "This account does not exist.";
            }

            // Join 3 table: Account, Role, Decentralization to get Role name and User name
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
        #endregion

        #region GetFullName function
        public string GetFullName(string userName, string password)
        {
            using var context = new BookContext();
            var user = context.Accounts.SingleOrDefault(a => a.UserName.Equals(userName) && a.Password.Equals(password));
            if (user == null)
            {
                return "This account does not exist.";
            }

            // Join 2 table: Account, Users to get Full name
            var getFullNameUser = from a in context.Accounts
                                        join b in context.Users
                                        on a.UserId equals b.UserId
                                        where a.AccountId.Equals(user.AccountId)
                                        select new User
                                        {
                                            FullName = b.FullName
                                        };
            var result = "";
            foreach (var check in getFullNameUser)
            {
                result = check.FullName;
            }
            return result;
        }
        #endregion

        #region Register function
        public string Register(string userName, string password, string phoneNumber, string city, string birthName, int age, string address, string email, string region, bool gender)
        {
            using var context = new BookContext();
            Random random = new Random();
            string message = "";
            try
            {

                User user = new User();

                user.UserId = random.Next();
                user.FullName = birthName;
                user.Age = age;
                user.Email = email;
                user.Gender = gender;
                user.PhoneNumber = phoneNumber;
                user.City = city;
                user.Address = address;
                user.Region = region;
                user.DateRegister = DateTime.Now;

                Account account = new Account();
                account.AccountId = random.Next();
                account.UserName = userName;
                account.Password = password;
                account.Star = 0;
                account.UserId = user.UserId;
                account.DateCreated = DateTime.Now;

                Decentralization decentralization = new Decentralization();
                decentralization.DecentralizationId = random.Next();
                decentralization.AccountId = account.AccountId;
                decentralization.RoleId = 3;
                decentralization.DateDecentralization = DateTime.Now;

                context.Users.Add(user);
                if (context.Users.Local.Any(u => u.UserId == user.UserId))
                {
                    var isUsernameExists = context.Accounts.Any(x => x.UserName.Equals(account.UserName));
                    if (isUsernameExists)
                    {
                        return message = "Username is already in use. Try another name.";
                    }
                    else
                    {
                        context.Accounts.Add(account);
                        if (context.Accounts.Local.Any(a => a.AccountId == account.AccountId))
                        {
                            context.Decentralizations.Add(decentralization);
                            context.SaveChanges();
                        }
                        else
                        {
                            return message = "Adding account failed. Please try again.";
                        }
                    }
                }
                else
                {
                    return message = "User added failed so couldn't add account. Please try again.";
                }
            }
            catch (DbUpdateException ex)
            {
                message = "Adding decentralization failed: " + ex.Message;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return message;
        }
        #endregion

        #region GetUserById function
        public User GetUserById(int id)
        {
            using var context = new BookContext();
            var checkUserContains = context.Users.FirstOrDefault(a => a.UserId == id);
            return checkUserContains;
        }
        #endregion

        #region UpdateUser function
        public void UpdateUser(User user)
        {
            using var context = new BookContext();
            try
            {
                var checkUserContains = GetUserById(user.UserId);
                if (checkUserContains != null)
                {
                    context.Entry<User>(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region DeleteUser function
        public void DeleteUser(int id)
        {
            using var context = new BookContext();
            try
            {
                var checkUserContains = GetUserById(id);
                if (checkUserContains != null)
                {
                    context.Users.Remove(checkUserContains);
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
