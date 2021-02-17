using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System;
using System.Net;

namespace MagmaPlayground_BackEnd.Services
{
    public class PluginService
    {
        private PluginDao pluginDao;
        private DawResponseFactory dawResponseFactory;
        private DawResponse dawResponse;

        public PluginService(MagmaDawDbContext magmaDbContext)
        {
            pluginDao = new PluginDao(magmaDbContext);
            dawResponseFactory = new DawResponseFactory();
            dawResponse = new DawResponse();
        }

        public DawResponse GetPluginById(int id)
        {
            dawResponse = new DawResponse();

            if (id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: plugin.Id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.plugin = pluginDao.GetPluginById(id);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            if (dawResponse.plugin == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: plugin not found", HttpStatusCode.NotFound);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse GetPluginByRackId(int rackId)
        {
            dawResponse = new DawResponse();

            if (rackId == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: rackId is null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.plugins = pluginDao.GetPluginsByRackId(rackId);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            if (dawResponse.plugins == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: plugins not found", HttpStatusCode.NotFound);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse CreatePlugin(Plugin plugin)
        {
            dawResponse = new DawResponse();

            if (plugin == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: plugin is null", HttpStatusCode.BadRequest);
            }

            if (plugin.id != 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: plugin.id is not null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.plugin = pluginDao.CreatePlugin(plugin);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse UpdatePlugin(Plugin plugin)
        {
            dawResponse = new DawResponse();

            if (plugin == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: plugin is null", HttpStatusCode.BadRequest);
            }

            if (plugin.id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: plugin.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.plugin = pluginDao.UpdatePlugin(plugin);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse DeletePlugin(Plugin plugin)
        {
            dawResponse = new DawResponse();

            if (plugin.id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: plugin.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                pluginDao.DeletePlugin(plugin);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }
    }
}
