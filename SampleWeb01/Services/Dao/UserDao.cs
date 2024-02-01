using SampleWeb01.Data;
using SampleWeb01.Models;

namespace SampleWeb01.Services.Dao
{
    

    public interface IUserDao
    {
        public bool create(TUser user ,TUserCompany userCompany);
    }

    public class UserDao : IUserDao
    {
        private readonly SampleWeb01Context _context;
        public UserDao(SampleWeb01Context context)
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
