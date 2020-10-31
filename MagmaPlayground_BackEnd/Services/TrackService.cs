using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Services
{
    public class TrackService
    {
        private TrackDao trackDao;
        private ResponseFactory responseFactory;
        private Response response;

        public TrackService(MagmaDbContext magmaDbContext)
        {
            trackDao = new TrackDao(magmaDbContext);
            responseFactory = new ResponseFactory();
        }

        public Response GetTrackById(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            response = trackDao.GetTrackById(id);

            if (response.track == null)
            {
                return responseFactory.CreateResponse("Error: track not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response GetTracksByProjectId(int projectId)
        {
            if (projectId == 0)
            {
                return responseFactory.CreateResponse("Error: input paramenter projectId is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            response = trackDao.GetTracksByProjectId(projectId);

            if (response.tracks == null)
            {
                return responseFactory.CreateResponse("Error: tracks not found for this project", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response CreateTrack(Track track)
        {
            if (track == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (track.id != 0)
            {
                return responseFactory.CreateResponse("Error: track already exists, id must be null", ResponseStatus.BADREQUEST);
            }

            response = trackDao.CreateTrack(track);

            return response;
        }

        public Response UpdateTrack(Track track)
        {
            if (track == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (track.id == 0)
            {
                return responseFactory.CreateResponse("Error: track id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            response = trackDao.UpdateTrack(track);

            return response;
        }

        public Response DeleteTrack(Track track)
        {
            if (track == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (track.id == 0)
            {
                return responseFactory.CreateResponse("Error: track id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            response = trackDao.DeleteTrack(track);

            return response;
        }
    }
}
