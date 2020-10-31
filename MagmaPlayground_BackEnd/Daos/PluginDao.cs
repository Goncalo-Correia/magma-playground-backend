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

            return responseFactory.UpdateResponse(response, "Success: found plugin", ResponseStatus.OK);
        }

        public Response GetPluginsByRackId(int rackId)
        {
            response = new Response();

            response.plugins = magmaDbContext.Plugins.Where<Plugin>(prop => prop.rack.id == rackId).ToList();

            return responseFactory.UpdateResponse(response, "Success: plugins found", ResponseStatus.OK);
        }

        public Response CreatePlugin(Plugin plugin)
        {
            response = new Response();

            response.plugin.id = magmaDbContext.Add<Plugin>(plugin).Entity.id;

            magmaDbContext.SaveChanges();

            return responseFactory.UpdateResponse(response, "Success: created plugin", ResponseStatus.OK);
        }

        public Response UpdatePlugin(Plugin plugin)
        {
            response = new Response();

            response.plugin.id = magmaDbContext.Update<Plugin>(plugin).Entity.id;

            magmaDbContext.SaveChanges();

            return responseFactory.UpdateResponse(response, "Success: updated plugin", ResponseStatus.OK);
        }

        public Response DeletePlugin(Plugin plugin)
        {
            magmaDbContext.Remove<Plugin>(plugin);

            magmaDbContext.SaveChanges();

            return responseFactory.CreateResponse("Success: deleted plugin", ResponseStatus.OK);
        }
    }
}