using System.Threading.Tasks;
using dsr_betalling.Common;

namespace dsr_betalling.Handler
{
    public static class AuthorizationHandler
    {
        /// <summary>
        /// Performs a basic Login check
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static async Task<bool> DoLogin(string username, string password)
        {
            var result = await Facade.DoLoginAsync(username, password);
            if (!result) return false;
            Authorization.UpdateUserList();
            Authorization.SetUserId(username);
            return true;
        }

        /// <summary>
        /// Performs a Logout, clearing the necesary variables
        /// </summary>
        /// <returns></returns>
        public static bool DoLogout()
        {
            var result = Facade.DoLogout();
            if (!result) return false;
            Authorization.Clear();
            return true;
        }
    }
}
