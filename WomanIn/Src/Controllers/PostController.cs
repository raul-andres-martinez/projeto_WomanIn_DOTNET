using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WomanInAPI.Src.Models;

namespace WomanInAPI.Src.Repo.Implementation
{
    [ApiController]
    [Route("api/Post")]
    [Produces("application/json")]

    public class PostController : ControllerBase
    {
        #region Attributes

        private readonly IPost _repo;

        #endregion

        #region Constructors
        public PostController(IPost repo)
        {
            _repo = repo;
        }
        #endregion

        #region Methods            

        /// <summary>
        /// Pegar todas Postagens
        /// </summary>        
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna a lista de Postagens</response>
        /// <response code="204">Resultado vazio</response>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAllPostsAsync()
        {
            var list = await _repo.GetAllPostsAsync();
            if (list.Count < 1) return NoContent();
            return Ok(list);
        }

        /// <summary>
        /// Pegar postagem pelo id
        /// </summary>
        /// <param name="idPost">id da Postagem</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna a Postagem</response>
        /// <response code="404">Postagem não existente</response>
        [HttpGet("id/{idPost}")]
        [Authorize]
        public async Task<ActionResult> GetPostByIdAsync([FromRoute] int idPost)
        {
            try
            {
                return Ok(await _repo.GetPostByIdAsync(idPost));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Criar nova Postagem
        /// </summary>
        /// <param name="post">Construtor para criar postagem</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        /// POST /api/Post
        /// {
        /// "Title/Título": "Vagas para programador .NET"
        /// "Description/Descrição": "Empresa X, com vaga para ...",
        /// "Post Date/Data de postagem": "13/09/2022"
        /// }
        ///
        /// </remarks>
        /// <response code="201">Retorna postagem criada</response>
        /// <response code="400">Retorna erro na criação</response>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> NewPostAsync([FromBody] Post post)
        {
            try
            {
                await _repo.NewPostAsync(post);
                return Created($"api/Post", post);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        /// <summary>
        /// Atualizar Postagem
        /// </summary>
        /// <param name="post">Construtor para atualizar postagem</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        /// PUT /api/Post
        /// {
        /// "Title/Título": "Vagas para programador .NET"
        /// "Description/Descrição": "Empresa X, com vaga para ...",
        /// "Post Date/Data de postagem": "13/09/2022"
        /// }
        ///
        /// </remarks>
        /// <response code="200">Retorna postagem atualizada</response>
        /// <response code="400">Retorna falha na atualização</response>
        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdatePostAsync([FromBody] Post post)
        {
            try
            {
                await _repo.UpdatePostAsync(post);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Deletar Postagem pelo id
        /// </summary>
        /// <param name="idPost">Construtor para deletar postagem</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        /// DELETE /api/Post/delete/{idPost}
        /// 
        /// </remarks>
        /// <response code="204">Retorna postagem deletado</response>
        /// <response code="404">Retorna postagem não existente</response>
        [HttpDelete("delete/{idPost}")]
        [Authorize]
        public async Task<ActionResult> DeletePostAsync([FromRoute] int idPost)
        {
            try
            {
                await _repo.DeletePostAsync(idPost);
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
