using BusinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserService
    {
        List<User> GetUsers();
        void AddNewUser(User user);

        void DeleteUser(User user);
        User GetUserById(int id);

        void UpdateUser(User user);

        IQueryable<User> SearchUser(string name);
    }
}
