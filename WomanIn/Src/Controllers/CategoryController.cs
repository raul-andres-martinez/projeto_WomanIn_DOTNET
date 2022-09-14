using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WomanInAPI.Src.Models;

namespace WomanInAPI.Src.Repo.Implementation
{
    [ApiController]
    [Route("api/Category")]
    [Produces("application/json")]

    public class CategoryController : ControllerBase
    {
        #region Attributes

        private readonly ICategory _repo;

        #endregion

        #region Constructors
        public CategoryController(ICategory repo)
        {
            _repo = repo;
        }
        #endregion
        #region Methods            

        /// <summary>
        /// Pegar todas Categorias
        /// </summary>        
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna a lista de Categorias</response>
        /// <response code="204">Resultado vazio</response>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAllCategoriesAsync()
        {
            var list = await _repo.GetAllCategoriesAsync();
            if (list.Count < 1) return NoContent();
            return Ok(list);
        }

        /// <summary>
        /// Pegar Categoria pelo id
        /// </summary>
        /// <param name="idCategory">id da Categoria</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna a Categoria</response>
        /// <response code="404">Categoria não existente</response>
        [HttpGet("id/{idCategory}")]
        [Authorize]
        public async Task<ActionResult> GetCategoryByIdAsync([FromRoute] int idCategory)
        {
            try
            {
                return Ok(await _repo.GetCategoryByIdAsync(idCategory));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Criar nova Categoria
        /// </summary>
        /// <param name="category">Construtor para criar categoria</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        /// POST /api/Category
        /// {
        /// "Name/Nome": "Economia",
        /// }
        ///
        /// </remarks>
        /// <response code="201">Retorna tema criado</response>
        /// <response code="400">Retorna erro na criação</response>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> NewCategoryAsync([FromBody] Category category)
        {
            try
            {
                await _repo.NewCategoryAsync(category);
                return Created($"api/Category", category);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Atualizar Categoria
        /// </summary>
        /// <param name="category">Construtor para atualizar Categoria</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        /// PUT /api/Category
        /// {
        /// "Name/Nome": "Economia",
        /// }
        ///
        /// </remarks>
        /// <response code="200">Retorna Categoria atualizada</response>
        /// <response code="400">Retorna erro na atualização</response>
        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> UpdateCategoryAsync([FromBody] Category category)
        {
            try
            {
                await _repo.UpdateCategoryAsync(category);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Deletar Categoria pelo id
        /// </summary>
        /// <param name="idCategory">Construtor para deletar Categoria</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        /// DELETE /api/Category/delete/{idCategory}
        /// 
        /// </remarks>
        /// <response code="204">Retorna Categoria deletada</response>
        /// <response code="404">Retorna Categoria não existente</response>
        [HttpDelete("delete/{idCategory}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> DeleteCategoryAsync([FromRoute] int idCategory)
        {
            try
            {
                await _repo.DeleteCategoryAsync(idCategory);
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
