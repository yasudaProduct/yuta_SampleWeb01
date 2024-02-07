namespace SampleWeb01.Application.Domain.Auth.Dto
{
    public class UserDataDto
    {
        public UserDataDto(string userId, string emailAddress, string userCls)
        {
            UserId = userId;
            EmailAddress = emailAddress;
            UserCls = userCls;
        }

        string UserId { get; set; }

        string EmailAddress { get; set; }

        string UserCls { get; set; }
    }
}
