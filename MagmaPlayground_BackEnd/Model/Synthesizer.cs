using MagmaPlayground_BackEnd.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Model
{
    public class Synthesizer
    {
        public int Id { get; set; }
        public string name { get; set; }
        public SynthesizerType synthesizerType { get; set; }

        public Synthesizer()
        {

        }
    }
}
