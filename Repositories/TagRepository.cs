using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using qa_server.Models;

namespace qa_server.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly CosmosDBConfig _cosmosDbConfig;
        private CosmosClient _cosmosClient;
        private Database _database;
        private string _containerName;

        public TagRepository(IOptions<CosmosDBConfig> CosmosDBConfig) { 
            _cosmosDbConfig = CosmosDBConfig.Value;
            _cosmosClient = new CosmosClient(_cosmosDbConfig.Account, _cosmosDbConfig.Key);
            _database = _cosmosClient.GetDatabase(_cosmosDbConfig.DatabaseName);
            _containerName = _cosmosDbConfig.TagContainerName;
        }

        public async Task<List<Tag>> GetAllTags()
        {
            List<Tag> tags = new List<Tag>();
            Container container = _database.GetContainer(_containerName);
            string query = "SELECT t.id, t.name FROM Tags t";

            QueryDefinition queryDefinition = new QueryDefinition(query);
            FeedIterator<Tag> feedIterator = container.GetItemQueryIterator<Tag>(queryDefinition);

            while (feedIterator.HasMoreResults)
            {
                FeedResponse<Tag> feedResponse = await feedIterator.ReadNextAsync();
                foreach(Tag tag in feedResponse)
                {
                    tags.Add(tag);
                }
            }
            return tags;
        }
    }
}
