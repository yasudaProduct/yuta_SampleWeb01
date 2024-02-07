using SampleWeb01.Application.Domain.Auth.Dto;
using SampleWeb01.Application.Domain.User.ValueObjects;

namespace SampleWeb01.Application.Interface
{
    public interface IUserRepository
    {
        public UserDataDto Find(UserId userId);
    }
}
