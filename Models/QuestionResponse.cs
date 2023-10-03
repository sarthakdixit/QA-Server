namespace qa_server.Models
{
    public class QuestionResponse
    {
        public int StatusCode { get; set; } = 200;
        public List<Question> Questions { get; set; }
        public string Message { get; set; }
    }
}
