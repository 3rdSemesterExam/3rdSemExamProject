using dsr_betalling.Interface;
// ReSharper disable UnassignedGetOnlyAutoProperty
// ReSharper disable UnusedMember.Local

namespace dsr_betalling.Model
{
    public class Activity : IWebUri
    {
        public Activity()
        {
            ResourceUri = "Activities";
            VerboseName = "Activities";
        }

        public Activity(string title) : this()
        {
            Title = title;
        }

        private int Id { get; }
        public string Title { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }
    }
}