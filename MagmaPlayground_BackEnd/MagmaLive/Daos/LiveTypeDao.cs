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

        public LiveType GetLiveTypeById(int id)
        {
            return magmaLiveDbContext.Find<LiveType>(id);
        }

        public LiveType CreateLiveType(LiveType liveType)
        {
            liveType = magmaLiveDbContext.Add<LiveType>(liveType).Entity;

            magmaLiveDbContext.SaveChanges();

            return liveType;
        }

        public LiveType UpdateLiveType(LiveType liveType)
        {
            liveType = magmaLiveDbContext.Update<LiveType>(liveType).Entity;

            magmaLiveDbContext.SaveChanges();

            return liveType;
        }

        public void DeleteLiveType(LiveType liveType)
        { 
            magmaLiveDbContext.Remove<LiveType>(liveType);

            magmaLiveDbContext.SaveChanges();
        }
    }
}
