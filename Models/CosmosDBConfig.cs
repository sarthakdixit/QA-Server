namespace qa_server.Models
{
    public class CosmosDBConfig
    {
        public string Account { get; set; }
        public string Key { get; set; }
        public string DatabaseName { get; set; }
        public string TagContainerName { get; set; }
        public string QuestionContainerName { get; set; }
        public string AnswerContainerName { get; set; }
    }
}
