using MagmaPlayground_BackEnd.MagmaDB.MagmaLive.MagmaDbContext;
using MagmaPlayground_BackEnd.Models.MagmaLive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaLive.Daos
{
    public class LiveFileTypeDao
    {
        private MagmaLiveDbContext magmaLiveDbContext;

        public LiveFileTypeDao(MagmaLiveDbContext magmaLiveDbContext)
        {
            this.magmaLiveDbContext = magmaLiveDbContext;
        }

        public LiveFileType GetLiveFileById(int id)
        {
            return magmaLiveDbContext.Find<LiveFileType>(id);
        }

        public LiveFileType CreateLiveFile(LiveFileType liveFileType)
        {
            return magmaLiveDbContext.Add<LiveFileType>(liveFileType).Entity;
        }

        public LiveFileType UpdateLiveFile(LiveFileType liveFileType)
        {
            return magmaLiveDbContext.Update<LiveFileType>(liveFileType).Entity;
        }

        public void DeleteLiveFile(LiveFileType liveFileType)
        {
            magmaLiveDbContext.Remove<LiveFileType>(liveFileType);
        }
    }
}
