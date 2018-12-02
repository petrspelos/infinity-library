using System;
using InfinityLibrary.Entities;
using InfinityLibrary.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.JSInterop;

namespace InfinityLibrary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly InfinityDbContext _context;

        public UsersController(InfinityDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            return _context.User;
        }

        // GET: api/Users
        [HttpGet("WithMembership")]
        public IEnumerable<User> GetUserWithMembership()
        {
            return _context.User.Where(u => u.HasValidMembership);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/Users/Update/5
        [HttpPost("Update/{id}")]
        public async Task<IActionResult> PutUser([FromRoute] long id, [FromForm] ClientEditUserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                Id = id,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Address = userModel.Address,
                Email = userModel.Email,
                DateOfBirth = new DateTime(userModel.YearOfBirth, userModel.MonthOfBirth, userModel.DayOfBirth),
                MembershipValidTill = new DateTime(userModel.MembershipEndYear, userModel.MembershipEndMonth, userModel.MembershipEndDay)
            };

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Redirect($"../../../userdetail/{user.Id}");
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromForm] ClientNewUserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dateOfBirth = new DateTime(userModel.YearOfBirth, userModel.MonthOfBirth, userModel.DayOfBirth);

            var user = new User
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Address = userModel.Address,
                DateOfBirth = dateOfBirth,
                Email = userModel.Email
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return Redirect($"../userdetail/{user.Id}");
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            if (_context.Reservation.Any(r => r.UserId == id))
            {
                return BadRequest("User has reservations");
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        private bool UserExists(long id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}