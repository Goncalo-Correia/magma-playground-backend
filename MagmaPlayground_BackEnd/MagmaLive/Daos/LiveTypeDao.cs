using MagmaPlayground_BackEnd.MagmaDB.MagmaLive.MagmaDbContext;
using MagmaPlayground_BackEnd.Models.MagmaLive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaLive.Daos
{
    public class LiveTypeDao
    {
        private MagmaLiveDbContext magmaLiveDbContext;

        public LiveTypeDao(MagmaLiveDbContext magmaLiveDbContext)
        {
            this.magmaLiveDbContext = magmaLiveDbContext;
        }

        public LiveType GetLiveFileById(int id)
        {
            return magmaLiveDbContext.Find<LiveType>(id);
        }

        public LiveType CreateLiveFile(LiveType liveFile)
        {
            return magmaLiveDbContext.Add<LiveType>(liveFile).Entity;
        }

        public LiveType UpdateLiveFile(LiveType liveFile)
        {
            return magmaLiveDbContext.Update<LiveType>(liveFile).Entity;
        }

        public void DeleteLiveFile(LiveType liveFile)
        {
            magmaLiveDbContext.Remove<LiveType>(liveFile);
        }
    }
}
