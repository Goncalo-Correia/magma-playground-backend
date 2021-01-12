using MagmaPlayground_BackEnd.MagmaDB.MagmaLive.MagmaDbContext;
using MagmaPlayground_BackEnd.Models.MagmaLive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaLive.Daos
{
    public class LiveFileDao
    {
        private MagmaLiveDbContext magmaLiveDbContext;

        public LiveFileDao(MagmaLiveDbContext magmaLiveDbContext)
        {
            this.magmaLiveDbContext = magmaLiveDbContext;
        }

        public LiveFile GetLiveFileById(int id)
        {
            return magmaLiveDbContext.Find<LiveFile>(id);
        }

        public LiveFile CreateLiveFile(LiveFile liveFile)
        {
            return magmaLiveDbContext.Add<LiveFile>(liveFile).Entity;
        }

        public LiveFile UpdateLiveFile(LiveFile liveFile)
        {
            return magmaLiveDbContext.Update<LiveFile>(liveFile).Entity;
        }

        public void DeleteLiveFile(LiveFile liveFile)
        {
            magmaLiveDbContext.Remove<LiveFile>(liveFile);
        }
    }
}
