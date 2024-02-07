using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUserRepository
    {
        public string Login(string userName, string password);
        public void UpdateUser(User user);
        public void DeleteUser(int id);
        public string Register(string userName, string password, string phoneNumber, string city, string birthName, int age, string address, string email, string region, bool gender);
        public IEnumerable<User> GetUsers();
        public string GetFullName(string userName, string password);
    }
}
