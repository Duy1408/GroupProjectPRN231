using BusinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Interface
{
    public interface ICommentRepo
    {
        List<Comment> GetComment();
        void AddNewComment(Comment comment);

        void DeleteComment(Comment comment);
        Comment GetCommentById(int id);

        void UpdateComment(Comment comment);
    }
}
