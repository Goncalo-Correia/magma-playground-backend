using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Model
{
    [Table("rack")]
    public class Rack
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        public List<Plugin> plugins { get; set; }

        public Rack()
        {

        }
    }
}
