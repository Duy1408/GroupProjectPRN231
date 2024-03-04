using BusinessObject.BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CommentDAO
    {
        private static CommentDAO instance;

        public static CommentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommentDAO();
                }
                return instance;
            }
        }

        public List<Comment> GetAllComment()
        {
            var _context = new TheRealEstateDBContext();
            return _context.Comments.Include(c => c.UserID).Include(c => c.RealEstateID).ToList();

        }


  
    }
}
