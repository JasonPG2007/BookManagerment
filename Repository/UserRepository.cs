using DataAccess;
using ObjectBusiness;
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
        public bool UpdateUser(User user) => UserDAO.Instance.UpdateUser(user);
        public void DeleteUser(int id) => UserDAO.Instance.DeleteUser(id);
        public string Register(string userName, string password, string phoneNumber, string city, string birthName, int age, string address, string email, string region, bool gender) => UserDAO.Instance.Register(userName, password, phoneNumber, city, birthName, age, address, email, region, gender);
        public IEnumerable<User> GetUsers() => UserDAO.Instance.GetUsers();
        public IEnumerable<User> GetFullName(string userName, string password) => UserDAO.Instance.GetFullName(userName, password);
        public IEnumerable<Account> GetUserAndAccount(string username) => UserDAO.Instance.GetUserAndAccount(username);
    }
}
