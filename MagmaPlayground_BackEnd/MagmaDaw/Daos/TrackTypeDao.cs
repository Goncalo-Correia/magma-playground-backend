using MagmaPlayground_BackEnd.MagmaDaw.Models;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaDaw.Daos
{
    public class TrackTypeDao
    {
        private MagmaDawDbContext magmaDawDbContext;

        public TrackTypeDao(MagmaDawDbContext magmaDawDbContext)
        {
            this.magmaDawDbContext = magmaDawDbContext;
        }

        public TrackType GetTrackTypeById(int id)
        {
            return magmaDawDbContext.Find<TrackType>(id);
        }

        public List<TrackType> GetTrackTypes()
        {
            return magmaDawDbContext.TrackTypes.ToList< TrackType>();
        }

        public TrackType CreateTrackType(TrackType trackType)
        {
            trackType.id = magmaDawDbContext.Add<TrackType>(trackType).Entity.id;

            magmaDawDbContext.SaveChanges();

            return trackType;
        }

        public TrackType UpdateTrackType(TrackType trackType)
        {
            trackType.id = magmaDawDbContext.Update<TrackType>(trackType).Entity.id;

            magmaDawDbContext.SaveChanges();

            return trackType;
        }

        public void DeleteTrackType(TrackType trackType)
        {
            magmaDawDbContext.Remove<TrackType>(trackType);

            magmaDawDbContext.SaveChanges();
        }
    }
}
