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

        /// <summary>
        /// Pegar usuário pelo Email
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna o usuario</response>
        /// <response code="404">E-mail não existente</response>
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

        /// <summary>
        /// Criar novo Usuário
        /// </summary>
        /// <param name="user">Construtor para criar usuário</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /api/User/{usuario.Email}
        ///     {
        ///         "Name": "Gustavo Boaz",
        ///         "Email": "gustavo@email.com",
        ///         "Password": "134652",
        ///         "CPF_CNPJ": "12345678901",
        ///         "Area": "Tecnologia"
        ///         "Tipo": "NORMAL"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna usuario criado</response>
        /// <response code="401">E-mail já cadastrado</response>
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
                return Unauthorized(new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Pegar Autorização
        /// </summary>
        /// <param name="user">Construtor para logar usuário</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /api/User/login
        ///     {
        ///         "E-mail": "gustavo@email.com",
        ///         "Password/Senha": "134652"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna usuario criado</response>
        /// <response code="401">E-mail ou senha invalido</response>
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

        /// <summary>
        /// Atualizar usuário
        /// </summary>
        /// <param name="user">Construtor para atualizar usuário</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /api/User
        ///     {
        ///         "Name/Nome": "Gustavo Boaz",
        ///         "E-mail": "gustavo@email.com",
        ///         "Password/Senha": "134652",
        ///         "Area": "Tecnologia"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Retorna usuário atualizado</response>
        /// <response code="400">Retorna falha na atualização</response>
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

        /// <summary>
        /// Deletar usuário pelo id
        /// </summary>
        /// <param name="email">Construtor para deletar usuário</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     DELETE /api/User/delete/{email}
        /// 
        /// </remarks>
        /// <response code="204">Retorna usuário deletada</response>
        /// <response code="404">Retorna usuário não existente</response>
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

