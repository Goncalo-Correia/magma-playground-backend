using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System;

namespace MagmaPlayground_BackEnd.Services
{
    public class PluginService
    {
        private PluginDao pluginDao;
        private DawResponseFactory responseFactory;
        private DawResponse response;

        public PluginService(MagmaDawDbContext magmaDbContext)
        {
            pluginDao = new PluginDao(magmaDbContext);
            responseFactory = new DawResponseFactory();
            response = new DawResponse();
        }

        public DawResponse GetPluginById(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = pluginDao.GetPluginById(id);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            if (response.plugin == null)
            {
                return responseFactory.CreateResponse("Error: plugin not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public DawResponse GetPluginByRackId(int rackId)
        {
            if (rackId == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = pluginDao.GetPluginsByRackId(rackId);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            if (response.plugins == null)
            {
                return responseFactory.CreateResponse("Error: plugins not found for this rack", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public DawResponse CreatePlugin(Plugin plugin)
        {
            if (plugin == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (plugin.id != 0)
            {
                return responseFactory.CreateResponse("Error: plugin already exists, id must be null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = pluginDao.CreatePlugin(plugin);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public DawResponse UpdatePlugin(Plugin plugin)
        {
            if (plugin == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (plugin.id == 0)
            {
                return responseFactory.CreateResponse("Error: plugin id is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = pluginDao.UpdatePlugin(plugin);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public DawResponse DeletePlugin(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: track id is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = pluginDao.DeletePlugin(id);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }
    }
}
