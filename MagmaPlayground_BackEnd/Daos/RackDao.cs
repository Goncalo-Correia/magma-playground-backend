using MagmaPlayground_BackEnd.Daos.Utilities;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Daos
{
    public class RackDao
    {
        private MagmaDbContext magmaDbContext;
        private ResponseFactory responseFactory;
        private Response response;

        public RackDao(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
            this.responseFactory = new ResponseFactory();
        }

        public Response GetRack(int id)
        {
            response = new Response();

            if (id == 0)
            {
                return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response.rack = magmaDbContext.Find<Rack>(id);
            response.message = "Success: found track";
            response.responseStatus = ResponseStatus.OK;

            if (response.rack == null)
            {
                return responseFactory.BuildResponse("Error: rack not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response GetRackByTrackId(int trackId)
        {
            try
            {
                if (trackId == 0)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                response.rack = magmaDbContext.Racks.Single<Rack>(prop => prop.trackId == trackId);
                response.message = "Success: rack found";
                response.responseStatus = ResponseStatus.OK;

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

                magmaDbContext.Add<Rack>(rack);
                magmaDbContext.SaveChanges();

            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return responseFactory.BuildResponse("Success: created rack", ResponseStatus.OK);
        }

        public Response UpdateRack(Rack rack)
        {
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

                magmaDbContext.Update<Rack>(rack);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return responseFactory.BuildResponse("Success: updated rack", ResponseStatus.OK);
        }

        public Response DeleteRack(Rack rack)
        {
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

                magmaDbContext.Remove<Rack>(rack);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return responseFactory.BuildResponse("Success: removed rack", ResponseStatus.OK);
        }
    }
}
