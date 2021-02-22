using MagmaPlayground_BackEnd.MagmaDaw.Models;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaDaw.Daos
{
    public class PluginTypeDao
    {
        private MagmaDawDbContext magmaDawDbContext;

        public PluginTypeDao(MagmaDawDbContext magmaDawDbContext)
        {
            this.magmaDawDbContext = magmaDawDbContext;
        }

        public PluginType GetPluginTypeById(int id)
        {
            return magmaDawDbContext.Find<PluginType>(id);
        }

        public List<PluginType> GetPluginTypes()
        {
            return magmaDawDbContext.PluginTypes.ToList<PluginType>();
        }

        public PluginType CreatePluginType(PluginType pluginType)
        {
            pluginType.id = magmaDawDbContext.Add<PluginType>(pluginType).Entity.id;

            magmaDawDbContext.SaveChanges();

            return pluginType;
        }

        public PluginType UpdatePluginType(PluginType pluginType)
        {
            pluginType.id = magmaDawDbContext.Update<PluginType>(pluginType).Entity.id;

            magmaDawDbContext.SaveChanges();

            return pluginType;
        }

        public void DeletePluginType(PluginType pluginType)
        {
            magmaDawDbContext.Remove<PluginType>(pluginType);

            magmaDawDbContext.SaveChanges();
        }
    }
}
