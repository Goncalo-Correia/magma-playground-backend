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
        private MagmaDawDbContext magmaDawDbContext;

        public PluginDao(MagmaDawDbContext magmaDawDbContext)
        {
            this.magmaDawDbContext = magmaDawDbContext;
        }

        public Plugin GetPluginById(int id)
        {
            return magmaDawDbContext.Find<Plugin>(id);
        }

        public List<Plugin> GetPluginsByRackId(int rackId)
        {
            return magmaDawDbContext.Plugins.Where<Plugin>(prop => prop.rack.id == rackId).ToList();
        }

        public Plugin CreatePlugin(Plugin plugin)
        {
            plugin.id = magmaDawDbContext.Add<Plugin>(plugin).Entity.id;

            magmaDawDbContext.SaveChanges();

            return plugin;
        }

        public Plugin UpdatePlugin(Plugin plugin)
        {
            plugin.id = magmaDawDbContext.Update<Plugin>(plugin).Entity.id;

            magmaDawDbContext.SaveChanges();

            return plugin;
        }

        public void DeletePlugin(Plugin plugin)
        {
            magmaDawDbContext.Remove<Plugin>(plugin);

            magmaDawDbContext.SaveChanges();
        }
    }
}