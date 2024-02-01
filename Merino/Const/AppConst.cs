using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merino.Const
{
    public class AppConst
    {

        public enum env
        {
            DEV = 1,
            UT = 2,
            IT = 3,
            ST = 4,
            UAT = 5,
            PROD = 6
        }

        public enum DbProvider
        {
            SqlServer = 1,
            PostgreSQL = 2
        }
    }
}
