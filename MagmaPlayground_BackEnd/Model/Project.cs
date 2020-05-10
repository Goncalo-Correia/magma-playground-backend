using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Model
{
    public class Project
    {
        public int Id;
        public string projectName { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime updateOn { get; set; }
        public List<Track> Tracks { get; set; }

        public Project()
        {

        }
    }
}
