using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System;
using System.Net;

namespace MagmaPlayground_BackEnd.Services
{
    public class RackService
    {
        private RackDao rackDao;
        private DawResponseFactory dawResponseFactory;
        private DawResponse dawResponse;

        public RackService(MagmaDawDbContext magmaDbContext)
        {
            rackDao = new RackDao(magmaDbContext);
            dawResponseFactory = new DawResponseFactory();
        }

        public DawResponse GetRackById(int id)
        {
            dawResponse = new DawResponse();

            if (id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: rack.id is null", HttpStatusCode.BadRequest);
            }
            
            try
            {
                dawResponse.rack = rackDao.GetRackById(id);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            if (dawResponse.rack == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: rack not found", HttpStatusCode.NotFound);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse CreateRack(Rack rack)
        {
            dawResponse = new DawResponse();

            if (rack == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: input parameter is null", HttpStatusCode.BadRequest);
            }

            if (rack.id != 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: rack.id must be null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.rack = rackDao.CreateRack(rack);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse UpdateRack(Rack rack)
        {
            dawResponse = new DawResponse();

            if (rack == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: rack is null", HttpStatusCode.BadRequest);
            }

            if (rack.id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: rack.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.rack = rackDao.UpdateRack(rack);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse DeleteRack(Rack rack)
        {
            dawResponse = new DawResponse();

            if (rack.id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: rack.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                rackDao.DeleteRack(rack);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }
    }
}
