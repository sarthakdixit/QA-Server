using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using qa_server.Models;
using qa_server.Services;

namespace qa_server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<TagResponse>> GetAllTags()
        {
            TagResponse tagResponse = await _tagService.GetAllTags();
            return Ok(tagResponse);
        }
    }
}
