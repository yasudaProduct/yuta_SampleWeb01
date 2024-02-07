using Merino.Service;
using SampleWeb01.Application.Domain.Auth;
using SampleWeb01.Application.Domain.User.ValueObjects;
using SampleWeb01.Application.Interface;
using SampleWeb01.Application.UseCase.Auth.Dto;
using System.Transactions;

namespace SampleWeb01.Application.UseCase
{

    public interface IAuthService
    {
        /// <summary>
        /// 認証
        /// </summary>
        /// <param name="req">パラメータ</param>
        /// <returns></returns>
        public AuthResponse Auth(AuthRequest req);

    }

    public class AuthService : MerinoService , IAuthService
    {
        
        private readonly IUserRepository _userRepository;

        private readonly IAuthManager _authManager;

        internal AuthService
            (
            IUserRepository userRepository,
            IAuthManager authManager
            ) 
        {
            _userRepository = userRepository;
            _authManager = authManager;
        }

        /// <summary>
        /// 認証
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public AuthResponse Auth(AuthRequest req) {

            UserId userId = new UserId(req.UserId);
            var result = _authManager.Login(userId, req.Password);

            if (result)
            {
                //TODO ユーザー再取得して返すか..
                return new AuthResponse(req.UserId, req.Password);
            }
            else
            {
                return null;
            }

            
        }
    }
}
