using Merino.Data;
using Merino.Service;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using yuta_SampleWeb01.Data;
using yuta_SampleWeb01.Entity;

namespace yuta_SampleWeb01.Services.Dao
{
    public class UserDao: MerinoDao
    {

        private readonly yuta_SampleWeb01Context _context;

        public UserDao(yuta_SampleWeb01Context context)
        {
            _context = context;
        }

        public void Create(TUserCompany userCompany)
        {
            //DbContextを取得したい。
            _context.TUserCompany.Add(userCompany);
            _context.SaveChanges();
        }

    }
}
