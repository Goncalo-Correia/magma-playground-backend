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

        public LiveFileType GetLiveFileTypeById(int id)
        {
            return magmaLiveDbContext.Find<LiveFileType>(id);
        }

        public LiveFileType CreateLiveFileType(LiveFileType liveFileType)
        {
            liveFileType = magmaLiveDbContext.Add<LiveFileType>(liveFileType).Entity; ;

            magmaLiveDbContext.SaveChanges();

            return liveFileType;
        }

        public LiveFileType UpdateLiveFileType(LiveFileType liveFileType)
        {
            liveFileType = magmaLiveDbContext.Update<LiveFileType>(liveFileType).Entity;

            magmaLiveDbContext.SaveChanges();

            return liveFileType;
        }

        public void DeleteLiveFileType(LiveFileType liveFileType)
        {
            magmaLiveDbContext.Remove<LiveFileType>(liveFileType);

            magmaLiveDbContext.SaveChanges();
        }
    }
}
