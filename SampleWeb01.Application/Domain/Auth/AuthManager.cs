using SampleWeb01.Application.Domain.User.ValueObjects;
using SampleWeb01.Application.Interface;

namespace SampleWeb01.Application.Domain.Auth
{


    internal interface IAuthManager
    {
        bool Login(UserId userId, string password);
    }

    internal class AuthManager: IAuthManager
    {
        private readonly IUserRepository _userRepository;

        public AuthManager(
            IUserRepository userRepository
            )
        {
            _userRepository = userRepository;
        }

        public bool Login(UserId userId, string password)
        {
            var user = _userRepository.Find(userId);

            if (user == null) return false;

            return false;
        }
    }
}
