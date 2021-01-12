using MagmaPlayground_BackEnd.Models.MagmaLive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaLive.Daos
{
    public class LiveDao
    {
        public LiveDao()
        {

        }

        public int CreateLive(Live live)
        {
            return live.id;
        }

        public int UpdateLive(Live live)
        {
            return live.id;
        }

        public int CreateOrUpdateLive(Live live)
        {
            return live.id;
        }

        public void DeleteLive(Live live)
        {

        }
    }
}
