using SampleWeb01.Application.Domain.User.ValueObjects;

namespace SampleWeb01.Application.Interface
{
    public interface IUserQueryService
    {
        internal void Auth(UserId userId, string password);
    }
}
