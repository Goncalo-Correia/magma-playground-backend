using MagmaPlayground_BackEnd.MagmaDaw.Daos;
using MagmaPlayground_BackEnd.MagmaDaw.Models;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaDaw.Services
{
    public class TrackTypeService
    {
        private TrackTypeDao trackTypeDao;
        private DawResponseFactory dawResponseFactory;
        private DawResponse dawResponse;

        public TrackTypeService(MagmaDawDbContext magmaDbContext)
        {
            trackTypeDao = new TrackTypeDao(magmaDbContext);
            dawResponseFactory = new DawResponseFactory();
        }

        public DawResponse GetTrackTypeById(int id)
        {
            dawResponse = new DawResponse();

            if (id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: trackType.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.trackType = trackTypeDao.GetTrackTypeById(id);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            if (dawResponse.trackType == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: trackType not found", HttpStatusCode.NotFound);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse GetTrackTypes()
        {
            dawResponse = new DawResponse();

            try
            {
                dawResponse.trackTypes = trackTypeDao.GetTrackTypes();
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            if (dawResponse.trackTypes == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: trackTypes not found", HttpStatusCode.NotFound);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse CreateTrackType(TrackType trackType)
        {
            dawResponse = new DawResponse();

            if (trackType == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: trackType is null", HttpStatusCode.BadRequest);
            }

            if (trackType.id != 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: trackType.id must be null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.trackType = trackTypeDao.CreateTrackType(trackType);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse UpdateTrackType(TrackType trackType)
        {
            dawResponse = new DawResponse();

            if (trackType == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: trackType is null", HttpStatusCode.BadRequest);
            }

            if (trackType.id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: trackType.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.trackType = trackTypeDao.UpdateTrackType(trackType);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse DeleteTrackType(int id)
        {
            dawResponse = new DawResponse();

            if (id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: trackType.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                trackTypeDao.DeleteTrackType(GetTrackTypeById(id).trackType);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }
    }
}
