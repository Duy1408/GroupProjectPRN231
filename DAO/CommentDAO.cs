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
            return _context.Comments.ToList();

        }


        public bool AddNewComment(Comment comment)
        {
            var _context = new TheRealEstateDBContext();
            var a = _context.Comments.SingleOrDefault(c => c.CommentID == comment.CommentID);

            if (a != null)
            {
                return false;
            }
            else
            {
                _context.Comments.Add(comment);
                _context.SaveChanges();
                return true;

            }
        }


        public bool UpdateComment(Comment comment)
        {
            var _context = new TheRealEstateDBContext();
            var a = _context.Comments.SingleOrDefault(c => c.CommentID == comment.CommentID);

            if (a == null)
            {
                return false;
            }
            else
            {
                _context.Entry(a).CurrentValues.SetValues(comment);
                _context.SaveChanges();
                return true;
            }
        }

        public Comment GetCommentByID(int id)
        {
            var _context = new TheRealEstateDBContext();
            return _context.Comments.SingleOrDefault(a => a.CommentID == id);
        }

        public void DeleteComment(Comment comment)
        {
            var _context = new TheRealEstateDBContext();

            var a = _context.Comments.FirstOrDefault(a => a.CommentID == comment.CommentID);
            _context.Comments.Remove(a);

            _context.SaveChanges();
        }

    }
}
