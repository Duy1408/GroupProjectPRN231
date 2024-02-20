using BusinessObject.BusinessObject;
using Repo.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private IUserRepo _user;
        public UserService(IUserRepo user)
        {
            _user = user;
        }

        public void AddNewUser(User user)
        {
            _user.AddNewUser(user);
        }

        public void DeleteUser(User user)
        {
            _user.DeleteUser(user);
        }

        public User GetUserById(int id)
        {
            return _user.GetUserById(id);
        }

        public List<User> GetUsers()
        {
            return _user.GetUsers();
        }

        public IQueryable<User> SearchUser(string name)
        {
            return _user.SearchUser(name);
        }

        public void UpdateUser(User user)
        {
            _user.UpdateUser(user);
        }
    }
}
