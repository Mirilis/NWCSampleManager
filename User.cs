using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWCSampleManager
{
    public partial class User
    {
        public static User GetCurrentUser()
        {
            var user = new User();
            using (var sql = new SampleTravellersContext())
            {
                var name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                user = sql.Users.Where(x => x.WindowsName == name).First();
            }
            return user;
        }

    }
}
