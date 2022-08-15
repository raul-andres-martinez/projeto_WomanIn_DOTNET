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

        [HttpGet]
        public async Task<ActionResult> GetAllPostsAsync()
        {
            var list = await _repo.GetAllPostsAsync();
            if (list.Count < 1) return NoContent();
            return Ok(list);
        }

        [HttpGet("id/{idPost}")]
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
        [HttpPost]
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
        [HttpPut]
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

        [HttpDelete("delete/{idPost}")]
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
