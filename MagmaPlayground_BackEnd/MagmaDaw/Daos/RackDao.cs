using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
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
            responseFactory = new ResponseFactory();
            response = new Response();
        }

        public Response GetRackById(int id)
        {
            response = responseFactory.CreateRackResponse();

            response.rack = magmaDbContext.Find<Rack>(id);

            return responseFactory.UpdateResponse(response, "Success: found track", ResponseStatus.OK);
        }

        public Response GetRackByTrackId(int trackId)
        {
            response = responseFactory.CreateRackResponse();

            response.rack = magmaDbContext.Racks.Single<Rack>(prop => prop.trackId == trackId);

            return responseFactory.UpdateResponse(response, "Success: rack found", ResponseStatus.OK);
        }

        public Response CreateRack(Rack rack)
        {
            response = responseFactory.CreateRackResponse();

            response.rack.id = magmaDbContext.Add<Rack>(rack).Entity.id;

            magmaDbContext.SaveChanges();

            return responseFactory.UpdateResponse(response, "Success: created rack", ResponseStatus.OK);
        }

        public Response UpdateRack(Rack rack)
        {
            response = responseFactory.CreateRackResponse();

            response.rack.id = magmaDbContext.Update<Rack>(rack).Entity.id;

            magmaDbContext.SaveChanges();

            return responseFactory.UpdateResponse(response, "Success: updated rack", ResponseStatus.OK);
        }

        public Response DeleteRack(int id)
        {
            magmaDbContext.Remove<Rack>(GetRackById(id).rack);

            magmaDbContext.SaveChanges();

            return responseFactory.CreateResponse("Success: removed rack", ResponseStatus.OK);
        }
    }
}
