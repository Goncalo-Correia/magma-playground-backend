using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.Daos.Utilities;
using Microsoft.EntityFrameworkCore;

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
                return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
            }

            daoResponse.plugin = magmaDbContext.Find<Plugin>(id);
            daoResponse.message = "Success: found plugin";
            daoResponse.isValid = true;

            if (daoResponse.plugin == null)
            {
                return daoResponseFactory.BuildDaoResponse("Error: plugin not found", false);
            }

            return daoResponse;
        }

        public DaoResponse CreatePlugin(Plugin plugin)
        {
            try
            {
                if (plugin == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
                }

                if (plugin.id != 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: plugin already exists, id must be null", false);
                }

                magmaDbContext.Add<Plugin>(plugin);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }

            return daoResponseFactory.BuildDaoResponse("Success: created plugin", true);
        }

        public DaoResponse UpdatePlugin(Plugin plugin)
        {
            try
            {
                if (plugin == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
                }

                if (plugin.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: plugin id is null", false);
                }

                magmaDbContext.Update<Plugin>(plugin);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }

            return daoResponseFactory.BuildDaoResponse("Success: updated plugin", true);
        }

        public DaoResponse DeletePlugin(Plugin plugin)
        {
            try
            {
                if (plugin == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
                }

                if (plugin.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: track id is null", false);
                }

                magmaDbContext.Remove<Plugin>(plugin);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }

            return daoResponseFactory.BuildDaoResponse("Success: deleted plugin", true);
        }
    }
}