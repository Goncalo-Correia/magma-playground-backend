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
            response = new Response();

            if (id == 0)
            {
                return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = rackDao.GetRackById(id);

            if (response.rack == null)
            {
                return responseFactory.BuildResponse("Error: rack not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response GetRackByTrackId(int trackId)
        {
            response = new Response();
            try
            {
                if (trackId == 0)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                response = rackDao.GetRackByTrackId(trackId);

                if (response.rack == null)
                {
                    return responseFactory.BuildResponse("Error: rack not found for this track", ResponseStatus.NOTFOUND);
                }
            }
            catch (ArgumentNullException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (InvalidOperationException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response CreateRack(Rack rack)
        {
            response = new Response();
            try
            {
                if (rack == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (rack.id != 0)
                {
                    return responseFactory.BuildResponse("Error: rack already exists, id must be null", ResponseStatus.BADREQUEST);
                }

                response = rackDao.CreateRack(rack);
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

        public Response UpdateRack(Rack rack)
        {
            response = new Response();
            try
            {
                if (rack == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (rack.id == 0)
                {
                    return responseFactory.BuildResponse("Error: rack id is null", ResponseStatus.BADREQUEST);
                }

                response = rackDao.UpdateRack(rack);
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

        public Response DeleteRack(Rack rack)
        {
            response = new Response();
            try
            {
                if (rack == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (rack.id == 0)
                {
                    return responseFactory.BuildResponse("Error: rack id is null", ResponseStatus.BADREQUEST);
                }

                response = rackDao.DeleteRack(rack);
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
