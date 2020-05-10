using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Model
{
    public class Rack
    {
        public int Id { get; set; }
        public string pluginName { get; set; }
        public List<Plugin> Plugins { get; set; }

        public Rack()
        {

        }
    }
}
