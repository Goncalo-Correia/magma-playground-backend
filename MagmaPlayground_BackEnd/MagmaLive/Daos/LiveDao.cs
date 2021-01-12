using MagmaPlayground_BackEnd.MagmaDB.MagmaLive.MagmaDbContext;
using MagmaPlayground_BackEnd.Models.MagmaLive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaLive.Daos
{
    public class LiveDao
    {
        private MagmaLiveDbContext magmaLiveDbContext;

        public LiveDao(MagmaLiveDbContext magmaLiveDbContext)
        {
            this.magmaLiveDbContext = magmaLiveDbContext;
        }

        public Live GetLiveById(int id)
        {
            return magmaLiveDbContext.Find<Live>(id);
        }

        public Live CreateLive(Live live)
        {
            return magmaLiveDbContext.Add<Live>(live).Entity;
        }

        public Live UpdateLive(Live live)
        {
            return magmaLiveDbContext.Update<Live>(live).Entity;
        }

        public void DeleteLive(Live live)
        {
            magmaLiveDbContext.Remove<Live>(live);
        }
    }
}
