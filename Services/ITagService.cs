using qa_server.Models;

namespace qa_server.Services
{
    public interface ITagService
    {
        Task<TagResponse> GetAllTags();
    }
}
