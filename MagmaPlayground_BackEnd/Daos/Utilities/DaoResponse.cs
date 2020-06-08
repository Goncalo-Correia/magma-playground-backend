using MagmaPlayground_BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Tools
{
    public class DaoResponse
    {
        public string message { get; set; }
        public bool isValid { get; set; }

        public Plugin plugin { get; set; }

        public DaoResponse()
        {
            plugin = null;
        }
    }
}
