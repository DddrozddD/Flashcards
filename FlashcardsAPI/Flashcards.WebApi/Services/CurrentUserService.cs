using Flashcards.Application.Interfaces;
using System.Security.Claims;

namespace Flashcards.WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _HttpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _HttpContextAccessor = httpContextAccessor;
        }


        public Guid UserId
        {
            get
            {
                var id = _HttpContextAccessor.HttpContext?.User?
                    .FindFirstValue(ClaimTypes.NameIdentifier);
                return string.IsNullOrEmpty(id) ? Guid.Empty : Guid.Parse(id);
            }
        }
    }
}
