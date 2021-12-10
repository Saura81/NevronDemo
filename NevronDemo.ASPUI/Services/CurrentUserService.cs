using NevronDemo.Application.Common.Interfaces;

namespace NevronDemo.ASPUI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public string UserId { get => "anonimous"; }

        public bool IsAuthenticated { get => false; }
    }
}
