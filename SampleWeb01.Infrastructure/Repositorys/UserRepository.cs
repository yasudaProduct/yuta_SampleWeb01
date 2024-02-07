using SampleWeb01.Application.Domain.Auth.Dto;
using SampleWeb01.Application.Domain.User.ValueObjects;
using SampleWeb01.Application.Interface;
using SampleWeb01.Infrastructure.Data;

namespace SampleWeb01.Infrastructure.Repositorys
{
    internal class UserRepository: IUserRepository
    {
        private readonly SqlServerDbContext _dbContext;
        public UserRepository(
            SqlServerDbContext dbContext
            )
        {
            _dbContext = dbContext;
        }

        public UserDataDto Find(UserId userId)
        {
            var user = _dbContext.MUser.Find(userId);

            return new UserDataDto(user.UserId.ToString(), user.MailAdress, user.UserCls);
        }
    }
}
