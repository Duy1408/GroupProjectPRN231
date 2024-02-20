using BusinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
   public  class UserDAO
    {

        private static UserDAO instance;

        public static UserDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDAO();
                }
                return instance;
            }
        }

        public List<User> GetAllUser()
        {
            var _context = new TheRealEstateDBContext();
            return _context.Users.ToList();
        }

        public bool AddNewUser(User user)
        {
            var _context = new TheRealEstateDBContext();
            var a = _context.Users.SingleOrDefault(c => c.UserID== user.UserID);

            if (a != null)
            {
                return false;
            }
            else
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;

            }
        }

        public bool UpdateUser(User user)
        {
            var _context = new TheRealEstateDBContext();
            var a = _context.Users.SingleOrDefault(c => c.UserID == user.UserID);

            if (a == null)
            {
                return false;
            }
            else
            {
                _context.Entry(a).CurrentValues.SetValues(user);
                _context.SaveChanges();
                return true;
            }
        }

        public User GetUserByID(int id)
        {
            var _context = new TheRealEstateDBContext();
            return _context.Users.SingleOrDefault(a => a.UserID == id);
        }

        public void DeleteUser(User user)
        {
            var _context = new TheRealEstateDBContext();

            var a = _context.Users.FirstOrDefault(a => a.UserID == user.UserID);
            _context.Users.Remove(a);

            _context.SaveChanges();
        }

        public IQueryable<User> SearchUserByName(string searchvalue)
        {
            var _context = new TheRealEstateDBContext();
            var a = _context.Users.Where(a => a.UserName.ToUpper().Contains(searchvalue.Trim().ToUpper()));


            return a;
        }
    }
}
