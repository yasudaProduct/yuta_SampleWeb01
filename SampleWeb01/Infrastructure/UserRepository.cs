using SampleWeb01.Data;

namespace SampleWeb01.Infrastructure
{
    public class UserRepository
    {

        private SampleWeb01Context _dbContext;

        public UserRepository(SampleWeb01Context dbContext)
        {
            _dbContext = dbContext;
        }

        //public User Find(string name)
        //{
        //    var target = _dbContext.TUser.FirstOrDefault(userData => userData.name == name.Value){

        //    }
        //}
    }
}
