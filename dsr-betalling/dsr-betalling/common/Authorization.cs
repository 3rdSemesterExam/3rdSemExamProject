using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dsr_betalling.Model;

namespace dsr_betalling.Common
{
    public static class Authorization
    {
        private static IEnumerable<User> userList;

        public static int UserId { get; private set; }
        public static string Username { get; private set; }

        public static async void UpdateUserList()
        {
            userList = await Facade.GetListAsync(new User());
        }

        public static void SetUserId(string username)
        {
            UserId = userList.FirstOrDefault(user => user.Username == username).Id;
        }

        public static void SetUsername(int userid)
        {
            Username = userList.FirstOrDefault(user => user.Id == userid).Username;
        }

        public static void Clear()
        {
            UserId = -1;
            Username = null;
        }
    }
}
