using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System;

namespace MagmaPlayground_BackEnd.Services
{
    public class RackService
    {
        private RackDao rackDao;
        private DawResponseFactory responseFactory;
        private DawResponse response;

        public RackService(MagmaDawDbContext magmaDbContext)
        {
            rackDao = new RackDao(magmaDbContext);
            responseFactory = new DawResponseFactory();
        }

        public DawResponse GetRackById(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();
            
            try
            {
                response = rackDao.GetRackById(id);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            if (response.rack == null)
            {
                return responseFactory.CreateResponse("Error: rack not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public DawResponse GetRackByTrackId(int trackId)
        {
            if (trackId == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = rackDao.GetRackByTrackId(trackId);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            if (response.rack == null)
            {
                return responseFactory.CreateResponse("Error: rack not found for this track", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public DawResponse CreateRack(Rack rack)
        {
            if (rack == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (rack.id != 0)
            {
                return responseFactory.CreateResponse("Error: rack already exists, id must be null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = rackDao.CreateRack(rack);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public DawResponse UpdateRack(Rack rack)
        {
            if (rack == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (rack.id == 0)
            {
                return responseFactory.CreateResponse("Error: rack id is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = rackDao.UpdateRack(rack);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public DawResponse DeleteRack(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: rack id is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = rackDao.DeleteRack(id);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }
    }
}
