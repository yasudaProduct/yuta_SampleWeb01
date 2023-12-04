using Humanizer;
using Microsoft.EntityFrameworkCore;
using yuta_SampleWeb01.Data;
using yuta_SampleWeb01.Entity;
using yuta_SampleWeb01.Models;

namespace yuta_SampleWeb01.Services
{
    public class UserService: Merino.MerinoService
    {
        private readonly yuta_SampleWeb01Context _context;

        public UserService(yuta_SampleWeb01Context context) 
        {
            _context = context;
        }

        public UserViewModel create(UserViewModel user) {

            //トランザクション
            using (var context = _context)
            {
                TUserCompany userCompany = new TUserCompany();

                userCompany.UserId = user.UserId;
                userCompany.CompanyName = user.CompanyName;
                userCompany.Remarks = user.Remarks;
                userCompany.DeletedFlg = "";
                userCompany.CreateDate = new DateTime();
                userCompany.CreateUserId = "test";
                userCompany.CreatePgmId = "test";
                userCompany.UpdateDate = new DateTime();
                userCompany.UpdateUserId = "test";
                userCompany.UpdatePgmId = "test";

                context.TUserCompany.Add(userCompany);

                context.SaveChanges();
                //context.TUserCompany.FirstOrDefaultAsync(m => m.UserId == user.UserId);

            };

            return null;
        }
    }
}
