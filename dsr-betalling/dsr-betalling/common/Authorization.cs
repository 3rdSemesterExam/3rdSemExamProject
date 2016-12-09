using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dsr_betalling.Model;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace dsr_betalling.Common
{
    public static class Authorization
    {
        private static IEnumerable<User> _userList;

        public static int UserId { get; private set; }
        public static string Username { get; private set; }

        /// <summary>
        /// Refreshes the UserList
        /// </summary>
        public static async void UpdateUserList()
        {
            _userList = await GetUserList();
        }

        /// <summary>
        /// Sets the UserId property, based on Username
        /// </summary>
        /// <param name="username"></param>
        public static void SetUserId(string username)
        {
            UserId = _userList.FirstOrDefault(user => user.Username == username).Id;
        }

        /// <summary>
        /// Sets the Username property, based on the UserId
        /// </summary>
        /// <param name="userid"></param>
        public static void SetUsername(int userid)
        {
            Username = _userList.FirstOrDefault(user => user.Id == userid).Username;
        }

        /// <summary>
        /// Clears the Class Properties (in connection with a Logout)
        /// </summary>
        public static void Clear()
        {
            UserId = -1;
            Username = null;
        }

        /// <summary>
        /// Gets a List of users from the Webservice
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<User>> GetUserList()
        {
            return await Facade.GetListAsync(new User());
        }
    }
}
