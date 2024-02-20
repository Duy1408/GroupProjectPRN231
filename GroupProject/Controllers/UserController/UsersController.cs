using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject.BusinessObject;
using Service.Interface;

namespace GroupProject.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _user;

        public UsersController(IUserService user)
        {
            _user = user;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
          if (_user.GetUsers() == null)
          {
              return NotFound();
          }
            return  _user.GetUsers().ToList();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
          if (_user.GetUsers()== null)
          {
              return NotFound();
          }
            var user =  _user.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (_user.GetUsers()==null)
            {
                return BadRequest();
            }


            try
            {

                _user.UpdateUser(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_user.GetUserById(id)==null)
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
          if (_user.GetUsers() == null)
          {
              return Problem("Entity set 'TheRealEstateDBContext.Users'  is null.");
          }
            _user.AddNewUser(user);

            return CreatedAtAction("GetUser", new { id = user.UserID }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_user.GetUsers()== null)
            {
                return NotFound();
            }
            var user = _user.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            _user.DeleteUser(user);

            return NoContent();
        }


    }
}
