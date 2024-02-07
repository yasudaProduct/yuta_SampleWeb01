namespace SampleWeb01.Application.UseCase.Auth.Dto
{
    public class AuthResponse
    {
        public AuthResponse(string userId, string password)
        {
            this.userId = userId;
        }

        public string userId;
    }
}
