using MagmaPlayground_BackEnd.MagmaDB.MagmaLive.MagmaDbContext;
using MagmaPlayground_BackEnd.Models.MagmaGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaGeneric.Daos
{
    public class FileTypeDao
    {
        private MagmaLiveDbContext magmaLiveDbContext;

        public FileTypeDao(MagmaLiveDbContext magmaLiveDbContext)
        {
            this.magmaLiveDbContext = magmaLiveDbContext;
        }

        public FileType GetFileTypeeById(int id)
        {
            return magmaLiveDbContext.Find<FileType>(id);
        }

        public FileType CreateFileType(FileType fileType)
        {
            return magmaLiveDbContext.Add<FileType>(fileType).Entity;
        }

        public FileType UpdateFileType(FileType fileType)
        {
            return magmaLiveDbContext.Update<FileType>(fileType).Entity;
        }

        public void DeleteFileType(FileType fileType)
        {
            magmaLiveDbContext.Remove<FileType>(fileType);
        }
    }
}
