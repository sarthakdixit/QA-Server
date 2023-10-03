using qa_server.Models;

namespace qa_server.Services
{
    public interface IAnswerService
    {
        public Task<AnswerResponse> PostAnswer(Answer answer);
        public Task<AnswerResponse> GetAnswers(string questionId);
    }
}
