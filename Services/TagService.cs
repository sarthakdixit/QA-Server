using qa_server.Models;
using qa_server.Repositories;

namespace qa_server.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<TagResponse> GetAllTags()
        {
            List<Tag> tags = await _tagRepository.GetAllTags();
            if (tags.Count == 0) throw new Exception("No tags found");
            TagResponse tagResponse = new TagResponse
            {
                Tags = tags,
                Message = "Data Fetched"
            };
            return tagResponse;
        }
    }
}
