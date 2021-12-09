using NevronDemo.Application.Common.Interfaces;

namespace NevronDemo.WebUI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public string UserId { get => "anonimous"; }

        public bool IsAuthenticated { get => false; }
    }
}
