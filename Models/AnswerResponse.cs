namespace qa_server.Models
{
    public class AnswerResponse
    {
        public int StatusCode { get; set; } = 200;
        public List<Answer> Answers { get; set; }
        public string Message { get; set; }
    }
}
