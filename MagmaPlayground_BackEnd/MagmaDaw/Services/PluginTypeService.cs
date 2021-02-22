using MagmaPlayground_BackEnd.MagmaDaw.Daos;
using MagmaPlayground_BackEnd.MagmaDaw.Models;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaDaw.Services
{
    public class PluginTypeService
    {
        private PluginTypeDao pluginTypeDao;
        private DawResponseFactory dawResponseFactory;
        private DawResponse dawResponse;

        public PluginTypeService(MagmaDawDbContext magmaDbContext)
        {
            pluginTypeDao = new PluginTypeDao(magmaDbContext);
            dawResponseFactory = new DawResponseFactory();
            dawResponse = new DawResponse();
        }

        public DawResponse GetPluginTypeById(int id)
        {
            dawResponse = new DawResponse();

            if (id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: pluginType.Id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.pluginType = pluginTypeDao.GetPluginTypeById(id);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            if (dawResponse.pluginType == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: pluginType not found", HttpStatusCode.NotFound);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse GetPluginTypes()
        {
            dawResponse = new DawResponse();

            try
            {
                dawResponse.pluginTypes = pluginTypeDao.GetPluginTypes();
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            if (dawResponse.pluginTypes == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: pluginTypes not found", HttpStatusCode.NotFound);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse CreatePluginType(PluginType pluginType)
        {
            dawResponse = new DawResponse();

            if (pluginType == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: pluginType is null", HttpStatusCode.BadRequest);
            }

            if (pluginType.id != 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: pluginType.id is not null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.pluginType = pluginTypeDao.CreatePluginType(pluginType);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse UpdatePluginType(PluginType pluginType)
        {
            dawResponse = new DawResponse();

            if (pluginType == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: pluginType is null", HttpStatusCode.BadRequest);
            }

            if (pluginType.id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: pluginType.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.pluginType = pluginTypeDao.UpdatePluginType(pluginType);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse DeletePluginType(int id)
        {
            dawResponse = new DawResponse();

            if (id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: pluginType.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                pluginTypeDao.DeletePluginType(GetPluginTypeById(id).pluginType);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }
    }
}
