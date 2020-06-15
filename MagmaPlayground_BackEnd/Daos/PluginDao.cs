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

        public Response GetPlugin(int id)
        {
            response = new Response();

            if (id == 0)
            {
                return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response.plugin = magmaDbContext.Find<Plugin>(id);
            response.message = "Success: found plugin";
            response.responseStatus = ResponseStatus.OK;

            if (response.plugin == null)
            {
                return responseFactory.BuildResponse("Error: plugin not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response GetPluginsByRackId(int rackId)
        {
            try
            {
                if (rackId == 0)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                response.plugins = magmaDbContext.Plugins.Where<Plugin>(prop => prop.rack.id == rackId).ToList();
                response.message = "Success: plugins found";
                response.responseStatus = ResponseStatus.OK;

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

                magmaDbContext.Add<Plugin>(plugin);
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

            return responseFactory.BuildResponse("Success: created plugin", ResponseStatus.OK);
        }

        public Response UpdatePlugin(Plugin plugin)
        {
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

                magmaDbContext.Update<Plugin>(plugin);
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

            return responseFactory.BuildResponse("Success: updated plugin", ResponseStatus.OK);
        }

        public Response DeletePlugin(Plugin plugin)
        {
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

                magmaDbContext.Remove<Plugin>(plugin);
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

            return responseFactory.BuildResponse("Success: deleted plugin", ResponseStatus.OK);
        }
    }
}