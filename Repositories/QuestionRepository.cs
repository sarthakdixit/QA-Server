using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using qa_server.Models;

namespace qa_server.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly CosmosDBConfig _cosmosDbConfig;
        private CosmosClient _cosmosClient;
        private Database _database;
        private string _containerName;

        public QuestionRepository(IOptions<CosmosDBConfig> CosmosDBConfig)
        {
            _cosmosDbConfig = CosmosDBConfig.Value;
            _cosmosClient = new CosmosClient(_cosmosDbConfig.Account, _cosmosDbConfig.Key);
            _database = _cosmosClient.GetDatabase(_cosmosDbConfig.DatabaseName);
            _containerName = _cosmosDbConfig.QuestionContainerName;
        }

        public async Task DeleteQuestion(string id)
        {
            Container container = _database.GetContainer(_containerName);
            Question question = await GetQuestionById(id);
            await container.DeleteItemAsync<Question>(id, new PartitionKey(question.Tag));
        }

        public async Task<List<Question>> GetAllQuestions()
        {
            List<Question> questions = new List<Question>();
            Container container = _database.GetContainer(_containerName);
            string query = "SELECT q.id, q.owner, q.heading, q.description, q.tag, q.createdOn FROM Questions q ORDER BY q.createdOn DESC";

            QueryDefinition queryDefinition = new QueryDefinition(query);
            FeedIterator<Question> feedIterator = container.GetItemQueryIterator<Question>(queryDefinition);

            while (feedIterator.HasMoreResults)
            {
                FeedResponse<Question> feedResponse = await feedIterator.ReadNextAsync();
                foreach (Question que in feedResponse)
                {
                    questions.Add(que);
                }
            }
            return questions;
        }

        public async Task<Question> GetQuestionById(string id)
        {
            Question question = null;
            Container container = _database.GetContainer(_containerName);
            string query = $"SELECT q.id, q.owner, q.description, q.tag, q.createdOn FROM Questions q WHERE q.id='{id}'";

            QueryDefinition queryDefinition = new QueryDefinition(query);
            FeedIterator<Question> feedIterator = container.GetItemQueryIterator<Question>(queryDefinition);

            while (feedIterator.HasMoreResults)
            {
                FeedResponse<Question> feedResponse = await feedIterator.ReadNextAsync();
                foreach (Question que in feedResponse)
                {
                    question = new Question
                    { 
                        Id = que.Id,
                        Owner = que.Owner,
                        Description = que.Description,
                        Heading = que.Heading,
                        Tag = que.Tag,
                        CreatedOn = que.CreatedOn,
                        UpdatedOn = que.UpdatedOn
                    };
                }
            }
            return question;
        }

        public async Task InsertQuestion(Question question)
        {
            Container container = _database.GetContainer(_containerName);
            Question newQuestion = new Question()
            {
                Id = question.Id,
                Owner = question.Owner,
                Heading = question.Heading,
                Description = question.Description,
                Tag = question.Tag,
                CreatedOn = question.CreatedOn,
                UpdatedOn = question.UpdatedOn
            };
            await container.CreateItemAsync<Question>(newQuestion, new PartitionKey(question.Tag));
        }

        public async Task<List<Question>> MyQuestions(string owner)
        {
            List<Question> questions = new List<Question>();
            Container container = _database.GetContainer(_containerName);
            string query = $"SELECT q.id, q.owner, q.heading, q.description, q.tag, q.createdOn FROM Questions q WHERE q.owner='{owner}' ORDER BY q.createdOn DESC";

            QueryDefinition queryDefinition = new QueryDefinition(query);
            FeedIterator<Question> feedIterator = container.GetItemQueryIterator<Question>(queryDefinition);

            while (feedIterator.HasMoreResults)
            {
                FeedResponse<Question> feedResponse = await feedIterator.ReadNextAsync();
                foreach (Question que in feedResponse)
                {
                    questions.Add(que);
                }
            }
            return questions;
        }

        public async Task UpdateQuestion(Question question)
        {
            Container container = _database.GetContainer(_containerName);
            await container.ReplaceItemAsync<Question>(question, question.Id, new PartitionKey(question.Tag));
        }
    }
}
