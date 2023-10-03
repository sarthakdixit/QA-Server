namespace qa_server.Models
{
    public class TagResponse
    {
        public int StatusCode { get; set; } = 200;
        public List<Tag> Tags { get; set; }
        public string Message { get; set; }
    }
}
