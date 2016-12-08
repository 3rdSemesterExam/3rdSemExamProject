using dsr_betalling.Interface;

namespace dsr_betalling.Model
{
    public class User : IWebUri
    {
        public int Id { get; set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public User()
        {
            ResourceUri = "Users";
            VerboseName = "Users";
        }

    }
}
