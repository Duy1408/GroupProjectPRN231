using BusinessObject.BusinessObject;
using DAO;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class UserRepo : IUserRepo
    {
        private UserDAO dao;
        public UserRepo()
        {
            dao = new UserDAO();
        }

        public void AddNewUser(User user)
        {
            dao.AddNewUser(user);
        }

        public void DeleteUser(User user)
        {
            dao.DeleteUser(user);
        }

        public User GetUserById(int id)
        {
            return dao.GetUserByID(id);
        }

        public List<User> GetUsers()
        {
            return dao.GetAllUser();
        }

        public IQueryable<User> SearchUser(string name)
        {
            return dao.SearchUserByName(name);
        }

        public void UpdateUser(User user)
        {
            dao.UpdateUser(user);
        }
    }
}
