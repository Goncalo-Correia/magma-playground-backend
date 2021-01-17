using MagmaPlayground_BackEnd.MagmaDB.MagmaLive.MagmaDbContext;
using MagmaPlayground_BackEnd.Models.MagmaGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaGeneric.Daos
{
    public class FileContentDao
    {
        private MagmaLiveDbContext magmaLiveDbContext;

        public FileContentDao(MagmaLiveDbContext magmaLiveDbContext)
        {
            this.magmaLiveDbContext = magmaLiveDbContext;
        }

        public FileContent GetFileContentById(int id)
        {
            return magmaLiveDbContext.Find<FileContent>(id);
        }

        public FileContent CreateFileContente(FileContent fileContent)
        {
            return magmaLiveDbContext.Add<FileContent>(fileContent).Entity;
        }

        public FileContent UpdateFileContent(FileContent fileContent)
        {
            return magmaLiveDbContext.Update<FileContent>(fileContent).Entity;
        }

        public void DeleteFileContent(FileContent fileContent)
        {
            magmaLiveDbContext.Remove<FileContent>(fileContent);
        }
    }
}
