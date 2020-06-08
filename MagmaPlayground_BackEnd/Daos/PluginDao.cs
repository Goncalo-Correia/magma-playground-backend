using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.Tools;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Daos
{
    public class PluginDao
    {
        private MagmaDbContext magmaDbContext;
        private DaoResponse daoResponse;

        public PluginDao(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
            this.daoResponse = new DaoResponse();
        }

        public DaoResponse GetPlugin (int id)
        {
            if (id == 0)
            {
                daoResponse.message = "Error: input parameter is null";
                daoResponse.isValid = false;

                return daoResponse;
            }

            daoResponse.plugin = magmaDbContext.Find<Plugin>(id);

            if (daoResponse.plugin == null)
            {
                daoResponse.message = "Error: plugin not found";
                daoResponse.isValid = false;

                return daoResponse;
            }

            daoResponse.message = "Succ ess: found plugin";
            daoResponse.isValid = true;

            return daoResponse;
        }

        public DaoResponse CreatePlugin (Plugin plugin)
        {
            try
            {
                if (plugin == null)
                {
                    daoResponse.message = "Error: input parameter is null";
                    daoResponse.isValid = false;

                    return daoResponse;
                }

                if (plugin.id != 0)
                {
                    daoResponse.message = "Error: plugin already exists, id must be null";
                    daoResponse.isValid = false;

                    return daoResponse;
                }

                magmaDbContext.Add<Plugin>(plugin);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                daoResponse.message = ex.InnerException.Message;
                daoResponse.isValid = false;

                return daoResponse;
            }
            catch (DbUpdateException ex)
            {
                daoResponse.message = ex.InnerException.Message;
                daoResponse.isValid = false;

                return daoResponse;
            }

            daoResponse.message = "Success: created plugin";
            daoResponse.isValid = true;

            return daoResponse;
        }

        public DaoResponse UpdatePlugin (Plugin plugin)
        {
            try
            {
                if (plugin == null)
                {
                    daoResponse.message = "Error: input parameter is null";
                    daoResponse.isValid = false;

                    return daoResponse;
                }

                if (plugin.id == 0)
                {
                    daoResponse.message = "Error: plugin id is null";
                    daoResponse.isValid = false;

                    return daoResponse;
                }

                magmaDbContext.Update<Plugin>(plugin);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                daoResponse.message = ex.InnerException.Message;
                daoResponse.isValid = false;

                return daoResponse;
            }
            catch (DbUpdateException ex)
            {
                daoResponse.message = ex.InnerException.Message;
                daoResponse.isValid = false;

                return daoResponse;
            }

            daoResponse.message = "Success: updated plugin";
            daoResponse.isValid = true;

            return daoResponse;
        }

        public DaoResponse DeletePlugin (Plugin plugin)
        {
            try
            {
                if (plugin == null)
                {
                    daoResponse.message = "Error: input parameter is null";
                    daoResponse.isValid = false;

                    return daoResponse;
                }

                if (plugin.id == 0)
                {
                    daoResponse.message = "Error: track id is null";
                    daoResponse.isValid = false;

                    return daoResponse;
                }

                magmaDbContext.Remove<Plugin>(plugin);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                daoResponse.message = ex.InnerException.Message;
                daoResponse.isValid = false;

                return daoResponse;
            }
            catch (DbUpdateException ex)
            {
                daoResponse.message = ex.InnerException.Message;
                daoResponse.isValid = false;

                return daoResponse;
            }

            daoResponse.message = "Success: deleted plugin";
            daoResponse.isValid = true;

            return daoResponse;
        }
    }
}
