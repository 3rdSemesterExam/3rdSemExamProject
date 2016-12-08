using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dsr_betalling.Common;

namespace dsr_betalling.Handler
{
    public class AuthorizationHandler
    {
        public bool DoLogin(string username, string password)
        {
            var result = Facade.DoLoginAsync(username, password).Result;
            Authorization.UpdateUserList();
            Authorization.SetUserId(username);
            return result;
        }

        public bool DoLogout()
        {
            var result = Facade.DoLogout();
            Authorization.Clear();
            return result;
        }
    }
}
