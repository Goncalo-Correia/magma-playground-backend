using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.Daos.Utilities;
using Microsoft.EntityFrameworkCore;
using MagmaPlayground_BackEnd.Utilities;

namespace MagmaPlayground_BackEnd.Daos
{
    public class PluginDao
    {
        private MagmaDbContext magmaDbContext;
        private DaoResponseFactory daoResponseFactory;
        private DaoResponse daoResponse;

        public PluginDao(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
            daoResponseFactory = new DaoResponseFactory();
        }

        public DaoResponse GetPlugin(int id)
        {
            daoResponse = new DaoResponse();

            if (id == 0)
            {
                return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            daoResponse.plugin = magmaDbContext.Find<Plugin>(id);
            daoResponse.message = "Success: found plugin";
            daoResponse.responseStatus = ResponseStatus.OK;

            if (daoResponse.plugin == null)
            {
                return daoResponseFactory.BuildDaoResponse("Error: plugin not found", ResponseStatus.NOTFOUND);
            }

            return daoResponse;
        }

        public DaoResponse CreatePlugin(Plugin plugin)
        {
            try
            {
                if (plugin == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (plugin.id != 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: plugin already exists, id must be null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Add<Plugin>(plugin);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return daoResponseFactory.BuildDaoResponse("Success: created plugin", ResponseStatus.OK);
        }

        public DaoResponse UpdatePlugin(Plugin plugin)
        {
            try
            {
                if (plugin == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (plugin.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: plugin id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Update<Plugin>(plugin);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return daoResponseFactory.BuildDaoResponse("Success: updated plugin", ResponseStatus.OK);
        }

        public DaoResponse DeletePlugin(Plugin plugin)
        {
            try
            {
                if (plugin == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (plugin.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: track id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Remove<Plugin>(plugin);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return daoResponseFactory.BuildDaoResponse("Success: deleted plugin", ResponseStatus.OK);
        }
    }
}