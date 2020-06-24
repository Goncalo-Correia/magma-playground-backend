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
            response = new Response();

            if (id == 0)
            {
                return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = pluginDao.GetPluginById(id);

            if (response.plugin == null)
            {
                return responseFactory.BuildResponse("Error: plugin not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response GetPluginByRackId(int rackId)
        {
            response = new Response();
            try
            {
                if (rackId == 0)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                response = pluginDao.GetPluginsByRackId(rackId);

                if (response.plugins == null)
                {
                    return responseFactory.BuildResponse("Error: plugins not found for this rack", ResponseStatus.NOTFOUND);
                }
            }
            catch (ArgumentNullException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response CreatePlugin(Plugin plugin)
        {
            response = new Response();
            try
            {
                if (plugin == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (plugin.id != 0)
                {
                    return responseFactory.BuildResponse("Error: plugin already exists, id must be null", ResponseStatus.BADREQUEST);
                }

                response = pluginDao.CreatePlugin(plugin);
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

        public Response UpdatePlugin(Plugin plugin)
        {
            response = new Response();
            try
            {
                if (plugin == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (plugin.id == 0)
                {
                    return responseFactory.BuildResponse("Error: plugin id is null", ResponseStatus.BADREQUEST);
                }

                response = pluginDao.UpdatePlugin(plugin);
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

        public Response DeletePlugin(Plugin plugin)
        {
            response = new Response();
            try
            {
                if (plugin == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (plugin.id == 0)
                {
                    return responseFactory.BuildResponse("Error: track id is null", ResponseStatus.BADREQUEST);
                }

                response = pluginDao.DeletePlugin(plugin);
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
