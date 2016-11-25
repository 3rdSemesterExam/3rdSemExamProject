using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsr_betalling.model
{
    class Activity
    {
        private int Id { get; set; }
        private string Title { get; set; }

        public Activity(string title)
        {
            Title = title;
        }

        public Activity(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
