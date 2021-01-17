using MagmaPlayground_BackEnd.MagmaDB.MagmaLive.MagmaDbContext;
using MagmaPlayground_BackEnd.Models.MagmaGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaGeneric.Daos
{
    public class FileDao
    {
        private MagmaLiveDbContext magmaLiveDbContext;

        public FileDao(MagmaLiveDbContext magmaLiveDbContext)
        {
            this.magmaLiveDbContext = magmaLiveDbContext;
        }

        public File GetFileById(int id)
        {
            return magmaLiveDbContext.Find<File>(id);
        }

        public File CreateFile(File file)
        {
            return magmaLiveDbContext.Add<File>(file).Entity;
        }

        public File UpdateFile(File file)
        {
            return magmaLiveDbContext.Update<File>(file).Entity;
        }

        public void DeleteFile(File file)
        {
            magmaLiveDbContext.Remove<File>(file);
        }
    }
}
