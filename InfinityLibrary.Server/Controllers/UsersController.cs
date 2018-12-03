using InfinityLibrary.Core.Providers;
using InfinityLibrary.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfinityLibrary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserProvider _userProvider;

        public UsersController(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<UserModel> GetUser()
        {
            return _userProvider.GetAll();
        }

        // GET: api/Users
        [HttpGet("WithMembership")]
        public IEnumerable<UserModel> GetUserWithMembership()
        {
            return _userProvider.GetAllWithMembership();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] long id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var user = await _userProvider.GetById(id);
            if (user == null) { return NotFound(); }
            return Ok(user);
        }

        // POST: api/Users/Update/5
        [HttpPost("Update/{id}")]
        public async Task<IActionResult> UpdateUserById([FromRoute] long id, [FromForm] UserModel userModel)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            userModel.Id = id;
            
            try
            {
                await _userProvider.Update(userModel);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }

            return Redirect($"../../../userdetail/{id}"); // TODO: Handle with Blazor
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromForm] UserModel userModel)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try
            {
                await _userProvider.Add(userModel);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }

            return Redirect($"../userdetail/{userModel.Id}"); // TODO: Handle with Blazor
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] long id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try
            {
                await _userProvider.DeleteById(id);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            
            return Ok();
        }
    }
}