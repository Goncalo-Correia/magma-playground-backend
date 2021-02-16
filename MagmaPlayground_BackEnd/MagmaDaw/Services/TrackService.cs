using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System;

namespace MagmaPlayground_BackEnd.Services
{
    public class TrackService
    {
        private TrackDao trackDao;
        private DawResponseFactory responseFactory;
        private DawResponse response;

        public TrackService(MagmaDawDbContext magmaDbContext)
        {
            trackDao = new TrackDao(magmaDbContext);
            responseFactory = new DawResponseFactory();
        }

        public DawResponse GetTrackById(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter id is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = trackDao.GetTrackById(id);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            if (response.track == null)
            {
                return responseFactory.CreateResponse("Error: track not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public DawResponse GetTracksByProjectId(int projectId)
        {
            if (projectId == 0)
            {
                return responseFactory.CreateResponse("Error: input paramenter projectId is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();
            
            try
            {
                response = trackDao.GetTracksByProjectId(projectId);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            if (response.tracks == null)
            {
                return responseFactory.CreateResponse("Error: tracks not found for this project", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public DawResponse CreateTrack(Track track)
        {
            if (track == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (track.id != 0)
            {
                return responseFactory.CreateResponse("Error: track already exists, id must be null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = trackDao.CreateTrack(track);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public DawResponse UpdateTrack(Track track)
        {
            if (track == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (track.id == 0)
            {
                return responseFactory.CreateResponse("Error: track id is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = trackDao.UpdateTrack(track);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public DawResponse DeleteTrack(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: track id is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = trackDao.DeleteTrack(id);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }
    }
}
