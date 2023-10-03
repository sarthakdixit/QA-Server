using qa_server.Models;
using qa_server.Repositories;

namespace qa_server.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IUserService _userService;

        public QuestionService(IQuestionRepository questionRepository, IUserService userService)
        {
            _questionRepository = questionRepository;
            _userService = userService;
        }

        public async Task<QuestionResponse> DeleteQuestion(string id)
        {
            await _questionRepository.DeleteQuestion(id);
            QuestionResponse response = new QuestionResponse
            {
                Message = "Question deleted"
            };
            return response;
        }

        public async Task<QuestionResponse> GetAllQuestions()
        {
            List<Question> result = await _questionRepository.GetAllQuestions();
            if (result.Count == 0) throw new Exception("No questions found");
            QuestionResponse response = new QuestionResponse
            {
                Questions = result,
                Message = "Fetched all questions"
            };
            return response;
        }

        public async Task<QuestionResponse> GetQuestionById(string id)
        {
            List<Question> questions = new List<Question>();
            Question question = await _questionRepository.GetQuestionById(id);
            if (question == null) throw new Exception("No question found");
            questions.Add(question);
            QuestionResponse response = new QuestionResponse
            {
                Questions = questions,
                Message = "Fetched details of question"
            };
            return response;
        }

        public async Task<QuestionResponse> InsertQuestion(Question question)
        {
            question.Id = Guid.NewGuid().ToString();
            question.Owner = _userService.GetUserId();
            DateTime date = DateTime.UtcNow;
            question.CreatedOn = date;
            question.UpdatedOn = date;
            await _questionRepository.InsertQuestion(question);
            return new QuestionResponse
            {
                Message = "Question saved"
            };
        }

        public async Task<QuestionResponse> MyQuestions()
        {
            string owner = _userService.GetUserId();
            List<Question> result = await _questionRepository.MyQuestions(owner);
            if (result.Count == 0) throw new Exception("No questions found");
            QuestionResponse response = new QuestionResponse
            {
                Questions = result,
                Message = "Fetched all questions"
            };
            return response;
        }

        public async Task<QuestionResponse> UpdateQuestion(Question question)
        {
            question.UpdatedOn = DateTime.UtcNow;
            await _questionRepository.UpdateQuestion(question);
            return new QuestionResponse
            {
                Message = "Question Updated"
            };
        }
    }
}
