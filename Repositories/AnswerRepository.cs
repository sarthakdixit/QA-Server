using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using qa_server.Models;

namespace qa_server.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly CosmosDBConfig _cosmosDbConfig;
        private CosmosClient _cosmosClient;
        private Database _database;
        private string _containerName;

        public AnswerRepository(IOptions<CosmosDBConfig> CosmosDBConfig)
        {
            _cosmosDbConfig = CosmosDBConfig.Value;
            _cosmosClient = new CosmosClient(_cosmosDbConfig.Account, _cosmosDbConfig.Key);
            _database = _cosmosClient.GetDatabase(_cosmosDbConfig.DatabaseName);
            _containerName = _cosmosDbConfig.AnswerContainerName;
        }

        public async Task<List<Answer>> GetAnswers(string questionId)
        {
            List<Answer> answers = new List<Answer>();
            Container container = _database.GetContainer(_containerName);
            string query = "SELECT a.id, a.owner, a.questionId, a.description, a.createdOn FROM Answeres a";

            QueryDefinition queryDefinition = new QueryDefinition(query);
            FeedIterator<Answer> feedIterator = container.GetItemQueryIterator<Answer>(queryDefinition);

            while (feedIterator.HasMoreResults)
            {
                FeedResponse<Answer> feedResponse = await feedIterator.ReadNextAsync();
                foreach (Answer ans in feedResponse)
                {
                    answers.Add(ans);
                }
            }
            return answers;
        }

        public async Task PostAnswer(Answer answer)
        {
            Container container = _database.GetContainer(_containerName);
            Answer ans = new Answer()
            {
                Id = answer.Id,
                Owner = answer.Owner,
                QuestionId = answer.QuestionId,
                Description = answer.Description,
                CreatedOn = answer.CreatedOn,
                UpdatedOn = answer.UpdatedOn
            };
            await container.CreateItemAsync<Answer>(ans, new PartitionKey(ans.QuestionId));
        }
    }
}
