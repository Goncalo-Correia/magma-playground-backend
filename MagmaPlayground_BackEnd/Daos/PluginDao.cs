using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using Microsoft.EntityFrameworkCore;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System.Linq;
using System;

namespace MagmaPlayground_BackEnd.Daos
{
    public class PluginDao
    {
        private MagmaDbContext magmaDbContext;
        private ResponseFactory responseFactory;
        private Response response;

        public PluginDao(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
            responseFactory = new ResponseFactory();
        }

        public Response GetPluginById(int id)
        {
            response = new Response();

            response.plugin = magmaDbContext.Find<Plugin>(id);
            response.message = "Success: found plugin";
            response.responseStatus = ResponseStatus.OK;

            return response;
        }

        public Response GetPluginsByRackId(int rackId)
        {
            response.plugins = magmaDbContext.Plugins.Where<Plugin>(prop => prop.rack.id == rackId).ToList();
            response.message = "Success: plugins found";
            response.responseStatus = ResponseStatus.OK;

            return response;
        }

        public Response CreatePlugin(Plugin plugin)
        {
            magmaDbContext.Add<Plugin>(plugin);
            magmaDbContext.SaveChanges();

            return responseFactory.BuildResponse("Success: created plugin", ResponseStatus.OK);
        }

        public Response UpdatePlugin(Plugin plugin)
        {
            magmaDbContext.Update<Plugin>(plugin);
            magmaDbContext.SaveChanges();

            return responseFactory.BuildResponse("Success: updated plugin", ResponseStatus.OK);
        }

        public Response DeletePlugin(Plugin plugin)
        {
            magmaDbContext.Remove<Plugin>(plugin);
            magmaDbContext.SaveChanges();

            return responseFactory.BuildResponse("Success: deleted plugin", ResponseStatus.OK);
        }
    }
}