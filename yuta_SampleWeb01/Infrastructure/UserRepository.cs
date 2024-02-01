using yuta_SampleWeb01.Data;

namespace yuta_SampleWeb01.Infrastructure
{
    public class UserRepository
    {

        private yuta_SampleWeb01Context _dbContext;

        public UserRepository(yuta_SampleWeb01Context dbContext)
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
