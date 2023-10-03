using Microsoft.Identity.Web;
using System.Security.Claims;

namespace qa_server.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            Guid userId;
            if (!Guid.TryParse(_httpContextAccessor.HttpContext?.User.GetObjectId(), out userId))
            {
                throw new Exception("User ID is not valid.");
            }
            return userId.ToString();
        }
    }
}
