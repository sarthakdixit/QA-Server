using qa_server.Models;

namespace qa_server.Services
{
    public interface IQuestionService
    {
        Task<QuestionResponse> GetAllQuestions();
        Task<QuestionResponse> MyQuestions();
        Task<QuestionResponse> GetQuestionById(string id);
        Task<QuestionResponse> UpdateQuestion(Question question);
        Task<QuestionResponse> DeleteQuestion(string id);
        Task<QuestionResponse> InsertQuestion(Question question);
    }
}
