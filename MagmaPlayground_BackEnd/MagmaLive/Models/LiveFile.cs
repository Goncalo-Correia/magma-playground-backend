using MagmaPlayground_BackEnd.Models.MagmaGeneric;
using MagmaPlayground_BackEnd.Models.MagmaLive.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Models.MagmaLive
{
    [Table("live_file")]
    public class LiveFile
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Column("url")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "URL is required")]
        public string url { get; set; }

        [Column("live_file_type_id")]
        [ForeignKey("livefile_livefiletype_fkey")]
        public int liveFileTypeId { get; set; }
        public LiveFileType liveFileType { get; set; }
        public Enum_LiveFileType enum_LiveFileType { get; set; }

        [Column("preview_file_id")]
        [ForeignKey("livefile_previewfile_fkey")]
        public int previewFileId { get; set; }
        public File previewFile { get; set; }

        [Column("live_type_id")]
        [ForeignKey("livefile_file_fkey")]
        public int fileId { get; set; }
        public File file { get; set; }
    }
}
