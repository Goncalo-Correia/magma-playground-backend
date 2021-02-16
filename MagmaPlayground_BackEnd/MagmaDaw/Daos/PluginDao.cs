using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using Microsoft.EntityFrameworkCore;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System.Linq;
using System;
using System.Collections.Generic;

namespace MagmaPlayground_BackEnd.Daos
{
    public class PluginDao
    {
        private MagmaDawDbContext magmaDbContext;

        public PluginDao(MagmaDawDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        public Plugin GetPluginById(int id)
        {
            return magmaDbContext.Find<Plugin>(id);
        }

        public List<Plugin> GetPluginsByRackId(int rackId)
        {
            return magmaDbContext.Plugins.Where<Plugin>(prop => prop.rack.id == rackId).ToList();
        }

        public Plugin CreatePlugin(Plugin plugin)
        {
            plugin.id = magmaDbContext.Add<Plugin>(plugin).Entity.id;

            magmaDbContext.SaveChanges();

            return plugin;
        }

        public Plugin UpdatePlugin(Plugin plugin)
        {
            plugin.id = magmaDbContext.Update<Plugin>(plugin).Entity.id;

            magmaDbContext.SaveChanges();

            return plugin;
        }

        public void DeletePlugin(Plugin plugin)
        {
            magmaDbContext.Remove<Plugin>(plugin);

            magmaDbContext.SaveChanges();
        }
    }
}