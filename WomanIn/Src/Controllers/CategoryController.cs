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

        [HttpGet]
        [Authorize]

        public async Task<ActionResult> GetAllCategoriesAsync()
        {
            var list = await _repo.GetAllCategoriesAsync();
            if (list.Count < 1) return NoContent();
            return Ok(list);
        }

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
