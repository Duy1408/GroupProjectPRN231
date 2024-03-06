using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject.BusinessObject;
using Service.Interface;

namespace GroupProject.Controllers.CommentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _comment;
        public CommentsController(ICommentService comment)
        {
            _comment = comment;
        }

        // GET: api/Comments
        [HttpGet]
        public ActionResult<IEnumerable<Comment>> GetComments()
        {
          if (_comment.GetComment()== null)
          {
              return NotFound();
          }
            return _comment.GetComment().ToList();
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public ActionResult<Comment>GetComment(int id)
        {
          if (_comment.GetComment() == null)
          {
              return NotFound();
            }
            var comment =  _comment.GetCommentById(id);


            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutComment(int id, Comment comment)
        {
            if (_comment.GetCommentById(id)==null)
            {
                return BadRequest();
            }

            try
            {

                _comment.UpdateComment(comment);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (_comment.GetCommentById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Comment> PostComment(Comment comment)
        {
          if (_comment.GetComment() == null)
          {
              return Problem("Entity set 'TheRealEstateDBContext.Comments'  is null.");
          }
            _comment.AddNewComment(comment);

            return CreatedAtAction("GetComment", new { id = comment.CommentID }, comment);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            if (_comment.GetComment() == null)
            {
                return NotFound();
            }
            var comment = _comment.GetCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }
            _comment.DeleteComment(comment);

            return NoContent();
        }

    
    }
}
