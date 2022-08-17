using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WomanInAPI.Src.Models;
using WomanInAPI.Src.Repo;

namespace WomanInAPI.Src.Controllers
{
    [ApiController]
    [Route("api/User")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        #region Attributes 
        private readonly IUser _repo;
        #endregion

        #region Constructors
        public UserController (IUser repo)
        {
            _repo = repo;
        }
        #endregion

        #region Methods
      
        [HttpGet("email/{email}")]
        public async Task<ActionResult> GetUserByEmailAsync([FromRoute] string email)
        {
            try
            {
                return Ok(await _repo.GetUserByEmailAsync(email));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<ActionResult> NewUserAsync([FromBody] User user)
        {
            try
            {
                await _repo.NewUserAsync(user);
                return Created($"api/User/{user.Email}", user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateUserAsync([FromBody] User user)
        {
            try
            {
                await _repo.UpdateUserAsync(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpDelete("delete/{email}")]
        public async Task<ActionResult> DeleteUserAsync([FromRoute] string email)
        {
            try
            {
                await _repo.DeleteUserAsync(email);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
        #endregion
    }
}

