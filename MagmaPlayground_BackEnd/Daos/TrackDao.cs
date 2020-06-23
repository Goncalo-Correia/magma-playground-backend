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
        private MagmaDbContext magmaDbContext;
        private ResponseFactory responseFactory;
        private Response response;

        public TrackDao(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
            this.responseFactory = new ResponseFactory();
        }

        public Response GetTrackById(int id)
        {
            response = new Response();

            response.track = magmaDbContext.Find<Track>(id);
            response.message = "Success: track found";
            response.responseStatus = ResponseStatus.OK;

            return response;
        }

        public Response GetTracksByProjectId(int projectId)
        {
            response = new Response();

            response.tracks = magmaDbContext.Tracks.Where<Track>(prop => prop.projectId == projectId).ToList();
            response.message = "Success: tracks found";
            response.responseStatus = ResponseStatus.OK;

            return response;
        }

        public Response CreateTrack(Track track)
        {
            magmaDbContext.Add<Track>(track);
            magmaDbContext.SaveChanges();

            return responseFactory.BuildResponse("Success: created track", ResponseStatus.OK);
        }

        public Response UpdateTrack(Track track)
        {
            magmaDbContext.Update<Track>(track);
            magmaDbContext.SaveChanges();

            return responseFactory.BuildResponse("Success: updated track", ResponseStatus.OK);
        }

        public Response DeleteTrack(Track track)
        {
            magmaDbContext.Remove<Track>(track);
            magmaDbContext.SaveChanges();

            return responseFactory.BuildResponse("Success: removed track", ResponseStatus.OK);
        }
    }
}