using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Daos
{
    public class TrackDao
    {
        private MagmaDawDbContext magmaDbContext;

        public TrackDao(MagmaDawDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        public Track GetTrackById(int id)
        {
            return magmaDbContext.Find<Track>(id);
        }

        public List<Track> GetTracksByProjectId(int projectId)
        {
            return magmaDbContext.Tracks.Where<Track>(prop => prop.projectId == projectId).ToList();
        }

        public Track CreateTrack(Track track)
        {
            track.id = magmaDbContext.Add<Track>(track).Entity.id;

            magmaDbContext.SaveChanges();

            return track;
        }

        public Track UpdateTrack(Track track)
        {
            track.id = magmaDbContext.Update<Track>(track).Entity.id;

            magmaDbContext.SaveChanges();

            return track;
        }

        public void DeleteTrack(Track track)
        {
            magmaDbContext.Remove<Track>(track);

            magmaDbContext.SaveChanges();
        }
    }
}