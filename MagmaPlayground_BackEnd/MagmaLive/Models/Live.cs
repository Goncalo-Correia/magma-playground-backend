using MagmaPlayground_BackEnd.Models.MagmaLive.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Models.MagmaLive
{
    [Table("live")]
    public class Live
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Column("name")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }

        [Column("description")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Description is required")]
        public string description { get; set; }

        [Column("uploaded_on")]
        [DataType(DataType.DateTime)]
        public DateTime uploadedOn { get; set; }
        
        [Column("live_file_id")]
        [ForeignKey("live_livefile_fkey")]
        public int? liveFileId { get; set; }
        public LiveFile liveFile { get; set; }

        [Column("live_type_id")]
        [ForeignKey("live_livetype_fkey")]
        public int? liveTypeId { get; set; }
        public LiveType liveType { get; set; }
    }
}
