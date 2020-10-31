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
    public class RackService
    {
        private RackDao rackDao;
        private ResponseFactory responseFactory;
        private Response response;

        public RackService(MagmaDbContext magmaDbContext)
        {
            rackDao = new RackDao(magmaDbContext);
            responseFactory = new ResponseFactory();
        }

        public Response GetRackById(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();
            
            response = rackDao.GetRackById(id);

            if (response.rack == null)
            {
                return responseFactory.CreateResponse("Error: rack not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response GetRackByTrackId(int trackId)
        {
            if (trackId == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            response = rackDao.GetRackByTrackId(trackId);

            if (response.rack == null)
            {
                return responseFactory.CreateResponse("Error: rack not found for this track", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response CreateRack(Rack rack)
        {
            if (rack == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (rack.id != 0)
            {
                return responseFactory.CreateResponse("Error: rack already exists, id must be null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            response = rackDao.CreateRack(rack);

            return response;
        }

        public Response UpdateRack(Rack rack)
        {
            if (rack == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (rack.id == 0)
            {
                return responseFactory.CreateResponse("Error: rack id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            response = rackDao.UpdateRack(rack);

            return response;
        }

        public Response DeleteRack(Rack rack)
        {
            if (rack == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (rack.id == 0)
            {
                return responseFactory.CreateResponse("Error: rack id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            response = rackDao.DeleteRack(rack);

            return response;
        }
    }
}
