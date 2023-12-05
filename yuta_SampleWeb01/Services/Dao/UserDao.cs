using yuta_SampleWeb01.Data;
using yuta_SampleWeb01.Models;

namespace yuta_SampleWeb01.Services.Dao
{
    

    public interface IUserDao
    {
        public bool create(TUser user ,TUserCompany userCompany);
    }

    public class UserDao : IUserDao
    {
        private readonly yuta_SampleWeb01Context _context;
        public UserDao(yuta_SampleWeb01Context context)
        {
            _context = context;
        }

        public bool create(TUser user, TUserCompany userCompany)
        {

            _context.TUser.Add(user);
            _context.TUserCompany.Add(userCompany);
            _context.SaveChanges();

            return true;
        }
    }
}
