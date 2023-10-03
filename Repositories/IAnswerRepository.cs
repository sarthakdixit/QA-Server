using qa_server.Models;

namespace qa_server.Repositories
{
    public interface IAnswerRepository
    {
        public Task PostAnswer(Answer answer);
        public Task<List<Answer>> GetAnswers(string questionId);
    }
}
