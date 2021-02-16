using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Daos
{
    public class RackDao
    {
        private MagmaDawDbContext magmaDbContext;

        public RackDao(MagmaDawDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        public Rack GetRackById(int id)
        {
            return magmaDbContext.Find<Rack>(id);
        }

        public Rack CreateRack(Rack rack)
        {
            rack.id = magmaDbContext.Add<Rack>(rack).Entity.id;

            magmaDbContext.SaveChanges();

            return rack;
        }

        public Rack UpdateRack(Rack rack)
        {
            rack.id = magmaDbContext.Update<Rack>(rack).Entity.id;

            magmaDbContext.SaveChanges();

            return rack;
        }

        public void DeleteRack(Rack rack)
        {
            magmaDbContext.Remove<Rack>(rack);

            magmaDbContext.SaveChanges();
        }
    }
}
