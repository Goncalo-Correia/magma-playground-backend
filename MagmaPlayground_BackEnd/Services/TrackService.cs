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
            response = new Response();

            if (id == 0)
            {
                return responseFactory.BuildResponse("Error: input parameter id is null", ResponseStatus.BADREQUEST);
            }

            response = trackDao.GetTrackById(id);

            if (response.track == null)
            {
                return responseFactory.BuildResponse("Error: track not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response GetTracksByProjectId(int projectId)
        {
            response = new Response();
            try
            {
                if (projectId == 0)
                {
                    return responseFactory.BuildResponse("Error: input paramenter projectId is null", ResponseStatus.BADREQUEST);
                }

                response = trackDao.GetTracksByProjectId(projectId);

                if (response.tracks == null)
                {
                    return responseFactory.BuildResponse("Error: tracks not found for this project", ResponseStatus.NOTFOUND);
                }
            }
            catch (ArgumentNullException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response CreateTrack(Track track)
        {
            response = new Response();
            try
            {
                if (track == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (track.id != 0)
                {
                    return responseFactory.BuildResponse("Error: track already exists, id must be null", ResponseStatus.BADREQUEST);
                }

                response = trackDao.CreateTrack(track);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response UpdateTrack(Track track)
        {
            response = new Response();
            try
            {
                if (track == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (track.id == 0)
                {
                    return responseFactory.BuildResponse("Error: track id is null", ResponseStatus.BADREQUEST);
                }

                response = trackDao.UpdateTrack(track);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response DeleteTrack(Track track)
        {
            response = new Response();
            try
            {
                if (track == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (track.id == 0)
                {
                    return responseFactory.BuildResponse("Error: track id is null", ResponseStatus.BADREQUEST);
                }

                response = trackDao.DeleteTrack(track);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }
    }
}
