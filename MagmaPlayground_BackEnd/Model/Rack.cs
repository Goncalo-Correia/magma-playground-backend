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
        public int Id { get; set; }

        [Required(ErrorMessage = "Plugin name is required")]
        public string pluginName { get; set; }

        public List<Plugin> Plugins { get; set; }

        public Rack()
        {

        }
    }
}
