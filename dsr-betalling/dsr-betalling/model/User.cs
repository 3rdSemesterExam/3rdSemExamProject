using dsr_betalling.Interface;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace dsr_betalling.Model
{
    public class User : IWebUri
    {
        public User()
        {
            ResourceUri = "Users";
            VerboseName = "Users";
        }

        public User(string username, string password) : this()
        {
            Username = username;
            Password = password;
        }

        internal int Id { get; set; }
        internal string Username { get; set; }
        private string Password { get; set; }

        // Interface Implementation
        public string ResourceUri { get; }
        public string VerboseName { get; }
    }
}