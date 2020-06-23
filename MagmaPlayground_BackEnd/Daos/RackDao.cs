﻿using MagmaPlayground_BackEnd.Model;
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
            this.responseFactory = new ResponseFactory();
        }

        public Response GetRackById(int id)
        {
            response = new Response();

            response.rack = magmaDbContext.Find<Rack>(id);
            response.message = "Success: found track";
            response.responseStatus = ResponseStatus.OK;

            return response;
        }

        public Response GetRackByTrackId(int trackId)
        {
            response.rack = magmaDbContext.Racks.Single<Rack>(prop => prop.trackId == trackId);
            response.message = "Success: rack found";
            response.responseStatus = ResponseStatus.OK;

            return response;
        }

        public Response CreateRack(Rack rack)
        {
            magmaDbContext.Add<Rack>(rack);
            magmaDbContext.SaveChanges();

            return responseFactory.BuildResponse("Success: created rack", ResponseStatus.OK);
        }

        public Response UpdateRack(Rack rack)
        {
            magmaDbContext.Update<Rack>(rack);
            magmaDbContext.SaveChanges();

            return responseFactory.BuildResponse("Success: updated rack", ResponseStatus.OK);
        }

        public Response DeleteRack(Rack rack)
        {
            magmaDbContext.Remove<Rack>(rack);
            magmaDbContext.SaveChanges();

            return responseFactory.BuildResponse("Success: removed rack", ResponseStatus.OK);
        }
    }
}
