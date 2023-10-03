using qa_server.Models;

namespace qa_server.Repositories
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAllQuestions();
        Task<Question> GetQuestionById(string id);
        Task UpdateQuestion(Question question);
        Task DeleteQuestion(string id);
        Task InsertQuestion(Question question);
        Task<List<Question>> MyQuestions(string owner);
    }
}
