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
            responseFactory = new ResponseFactory();
            response = new Response();
        }

        public Response GetTrackById(int id)
        {
            response = responseFactory.CreateTrackResponse();

            response.track = magmaDbContext.Find<Track>(id);

            return responseFactory.UpdateResponse(response, "Success: track found", ResponseStatus.OK);
        }

        public Response GetTracksByProjectId(int projectId)
        {
            response = responseFactory.CreateTrackResponse();

            response.tracks = magmaDbContext.Tracks.Where<Track>(prop => prop.projectId == projectId).ToList();

            return responseFactory.UpdateResponse(response, "Success: tracks found", ResponseStatus.OK);
        }

        public Response CreateTrack(Track track)
        {
            response = responseFactory.CreateTrackResponse();

            response.track.id = magmaDbContext.Add<Track>(track).Entity.id;

            magmaDbContext.SaveChanges();

            return responseFactory.UpdateResponse(response, "Success: created track", ResponseStatus.OK);
        }

        public Response UpdateTrack(Track track)
        {
            response = responseFactory.CreateTrackResponse();

            response.track.id = magmaDbContext.Update<Track>(track).Entity.id;

            magmaDbContext.SaveChanges();

            return responseFactory.UpdateResponse(response, "Success: updated track", ResponseStatus.OK);
        }

        public Response DeleteTrack(int id)
        {
            magmaDbContext.Remove<Track>(GetTrackById(id).track);

            magmaDbContext.SaveChanges();

            return responseFactory.CreateResponse("Success: removed track", ResponseStatus.OK);
        }
    }
}