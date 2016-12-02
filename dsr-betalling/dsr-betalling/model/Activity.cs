using dsr_betalling.Interface;

namespace dsr_betalling.Model
{
    class Activity : IWebUri
    {
        public int Id { get; }
        public string Title { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public Activity()
        {
            ResourceUri = "Activities";
            VerboseName = "Activities";
        }

        public Activity(string title) : this()
        {
            Title = title;
        }

        public Activity(int id, string title) : this()
        {
            Id = id;
            Title = title;
        }

    }
}
