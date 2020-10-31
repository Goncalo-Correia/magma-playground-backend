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
    public class PluginService
    {
        private PluginDao pluginDao;
        private ResponseFactory responseFactory;
        private Response response;

        public PluginService(MagmaDbContext magmaDbContext)
        {
            pluginDao = new PluginDao(magmaDbContext);
            responseFactory = new ResponseFactory();
            response = new Response();
        }

        public Response GetPluginById(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            response = pluginDao.GetPluginById(id);

            if (response.plugin == null)
            {
                return responseFactory.CreateResponse("Error: plugin not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response GetPluginByRackId(int rackId)
        {
            if (rackId == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            response = pluginDao.GetPluginsByRackId(rackId);

            if (response.plugins == null)
            {
                return responseFactory.CreateResponse("Error: plugins not found for this rack", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response CreatePlugin(Plugin plugin)
        {
            if (plugin == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (plugin.id != 0)
            {
                return responseFactory.CreateResponse("Error: plugin already exists, id must be null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            response = pluginDao.CreatePlugin(plugin);

            return response;
        }

        public Response UpdatePlugin(Plugin plugin)
        {
            if (plugin == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (plugin.id == 0)
            {
                return responseFactory.CreateResponse("Error: plugin id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            response = pluginDao.UpdatePlugin(plugin);

            return response;
        }

        public Response DeletePlugin(Plugin plugin)
        {
            if (plugin == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (plugin.id == 0)
            {
                return responseFactory.CreateResponse("Error: track id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            response = pluginDao.DeletePlugin(plugin);

            return response;
        }
    }
}
