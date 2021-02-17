using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System;
using System.Net;

namespace MagmaPlayground_BackEnd.Services
{
    public class TrackService
    {
        private TrackDao trackDao;
        private DawResponseFactory dawResponseFactory;
        private DawResponse dawResponse;

        public TrackService(MagmaDawDbContext magmaDbContext)
        {
            trackDao = new TrackDao(magmaDbContext);
            dawResponseFactory = new DawResponseFactory();
        }

        public DawResponse GetTrackById(int id)
        {
            dawResponse = new DawResponse();

            if (id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: track.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.track = trackDao.GetTrackById(id);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            if (dawResponse.track == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: track not found", HttpStatusCode.NotFound);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse GetTracksByProjectId(int projectId)
        {
            dawResponse = new DawResponse();

            if (projectId == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: projectId is null", HttpStatusCode.BadRequest);
            }
            
            try
            {
                dawResponse.tracks = trackDao.GetTracksByProjectId(projectId);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            if (dawResponse.tracks == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: tracks not found", HttpStatusCode.NotFound);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse CreateTrack(Track track)
        {
            dawResponse = new DawResponse();

            if (track == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: track is null", HttpStatusCode.BadRequest);
            }

            if (track.id != 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: track.id must be null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.track = trackDao.CreateTrack(track);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse UpdateTrack(Track track)
        {
            dawResponse = new DawResponse();

            if (track == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: track is null", HttpStatusCode.BadRequest);
            }

            if (track.id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: track.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.track = trackDao.UpdateTrack(track);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse DeleteTrack(int id)
        {
            dawResponse = new DawResponse();

            if (id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: track.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                trackDao.DeleteTrack(GetTrackById(id).track);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }
    }
}
