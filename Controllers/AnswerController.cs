using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using qa_server.Models;
using qa_server.Services;

namespace qa_server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<AnswerResponse>> PostAnswer([FromBody] Answer answer)
        {
            AnswerResponse response = await _answerService.PostAnswer(answer);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<AnswerResponse>> GetAnswers(string questionId)
        {
            AnswerResponse response = await _answerService.GetAnswers(questionId);
            return Ok(response);
        }
    }
}
