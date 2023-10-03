using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using qa_server.Models;
using qa_server.Services;

namespace qa_server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }


        [HttpGet("[action]")]
        public async Task<ActionResult<QuestionResponse>> GetAllQuestions()
        {
            QuestionResponse result = await _questionService.GetAllQuestions();
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<QuestionResponse>> MyQuestions()
        {
            QuestionResponse result = await _questionService.MyQuestions();
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<QuestionResponse>> GetQuestionById(string id)
        {
            QuestionResponse result = await _questionService.GetQuestionById(id);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<QuestionResponse>> InsertQuestion([FromBody] Question question)
        {
            QuestionResponse result = await _questionService.InsertQuestion(question);
            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<QuestionResponse>> UpdateQuestion([FromBody] Question question)
        {
            QuestionResponse result = await _questionService.UpdateQuestion(question);
            return Ok(result);
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult<QuestionResponse>> DeleteQuestion(string id)
        {
            QuestionResponse result = await _questionService.DeleteQuestion(id);
            return Ok(result);
        }
    }
}
