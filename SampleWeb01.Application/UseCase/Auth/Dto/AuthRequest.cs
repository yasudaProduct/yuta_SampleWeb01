namespace SampleWeb01.Application.UseCase.Auth.Dto
{
    public class AuthRequest
    {
        public AuthRequest(string userId, string password)
        {
            this.UserId = userId;
            this.Password = password;
        }

        public string UserId;

        public string Password;
    }
}
