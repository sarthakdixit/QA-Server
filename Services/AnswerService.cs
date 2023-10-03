using qa_server.Models;
using qa_server.Repositories;

namespace qa_server.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IUserService _userService;

        public AnswerService(IAnswerRepository answerRepository, IUserService userService)
        {
            _answerRepository = answerRepository;
            _userService = userService;
        }

        public async Task<AnswerResponse> GetAnswers(string questionId)
        {
            List<Answer> answers = await _answerRepository.GetAnswers(questionId);
            if (answers.Count == 0) throw new Exception("No question found");
            AnswerResponse response = new AnswerResponse
            {
                Answers = answers,
                Message = "Fetched details of question"
            };
            return response;
        }

        public async Task<AnswerResponse> PostAnswer(Answer answer)
        {
            answer.Id = Guid.NewGuid().ToString();
            answer.Owner = _userService.GetUserId();
            DateTime date = DateTime.UtcNow;
            answer.CreatedOn = date;
            answer.UpdatedOn = date;
            await _answerRepository.PostAnswer(answer);
            return new AnswerResponse
            {
                Message = "Question saved"
            };
        }
    }
}
