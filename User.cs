using System.Linq;

namespace NWCSampleManager
{
    public partial class User
    {
        #region Public Methods

        public static User GetCurrentUser()
        {
            var user = new User();
            using (var sql = new SampleTravelersContext())
            {
                var name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                user = sql.Users.Where(x => x.WindowsName == name).First();
            }
            return user;
        }

        #endregion Public Methods
    }
}