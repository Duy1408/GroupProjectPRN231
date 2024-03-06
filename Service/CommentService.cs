using BusinessObject.BusinessObject;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CommentService : ICommentService
    {
        private ICommentService _service;
        public CommentService(ICommentService service)
        {
            _service = service;
        }

        public void AddNewComment(Comment comment)
        {
            _service.AddNewComment(comment);
        }

        public void DeleteComment(Comment comment)
        {
            _service.DeleteComment(comment);
        }

        public List<Comment> GetComment()
        {
            return _service.GetComment();
        }

        public Comment GetCommentById(int id)
        {
            return _service.GetCommentById(id);
        }

        public void UpdateComment(Comment comment)
        {
           _service.UpdateComment(comment);
        }
    }
}
