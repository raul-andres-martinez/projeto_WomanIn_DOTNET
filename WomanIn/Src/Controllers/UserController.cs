using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WomanInAPI.Src.Models;
using WomanInAPI.Src.Repo;
using WomanInAPI.Src.Services;

namespace WomanInAPI.Src.Controllers
{
    [ApiController]
    [Route("api/User")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        #region Attributes 
        private readonly IUser _repo;
        private readonly IAuthentication _services;

        #endregion

        #region Constructors
        public UserController (IUser repo, IAuthentication services)
        {
            _repo = repo;
            _services = services;
        }
        #endregion

        #region Methods
      
        [HttpGet("email/{email}")]
        [Authorize(Roles = "NORMAL,ADMIN")]

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
        [HttpPost("register/new_user")]
        [AllowAnonymous]
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
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> LoginAsync([FromBody] User user)
        {
            var auxiliar = await _repo.GetUserByEmailAsync(user.Email);
            if (auxiliar == null) return Unauthorized(new
            {
                Message = "E-mail invalido"
            });
            if (auxiliar.Password != _services.EncodePassword(user.Password))
                return Unauthorized(new { Message = "Senha invalida" });
            var token = "Bearer " + _services.GenerateToken(auxiliar);
            return Ok(new { User = auxiliar, Token = token });
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

