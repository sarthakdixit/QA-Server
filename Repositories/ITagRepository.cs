using qa_server.Models;

namespace qa_server.Repositories
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetAllTags();
    }
}
