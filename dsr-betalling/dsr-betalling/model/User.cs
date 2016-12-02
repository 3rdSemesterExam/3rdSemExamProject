using dsr_betalling.Interface;

namespace dsr_betalling.Model
{
    class User : IWebUri
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public User()
        {
            ResourceUri = "Users";
            VerboseName = "Users";
        }

    }
}
