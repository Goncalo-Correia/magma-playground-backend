using MagmaPlayground_BackEnd.MagmaDB.MagmaLive.MagmaDbContext;
using MagmaPlayground_BackEnd.MagmaLive.Daos;
using MagmaPlayground_BackEnd.MagmaLive.Response;
using MagmaPlayground_BackEnd.Models.MagmaLive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaLive.Services
{
    public class LiveService
    {
        private LiveDao liveDao;
        private LiveResponseFactory liveResponseFactory;
        private LiveResponse liveResponse;

        public LiveService(MagmaLiveDbContext magmaLiveDbContext)
        {
            liveDao = new LiveDao(magmaLiveDbContext);
            liveResponseFactory = new LiveResponseFactory();
        }

        public LiveResponse GetLiveById(int id)
        {
            liveResponse = new LiveResponse();

            if (id == 0)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, "live.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                liveResponse.live = liveDao.GetLiveById(id);
            }
            catch (Exception ex)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return liveResponseFactory.CreateLiveResponse(liveResponse, "", HttpStatusCode.OK);
        }

        public LiveResponse CreateLive(Live live)
        {
            liveResponse = new LiveResponse();

            if (live.id != 0)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, "live.id is not null", HttpStatusCode.BadRequest);
            }

            try
            {
                liveResponse.live = liveDao.CreateLive(live);
            }
            catch (Exception ex)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return liveResponseFactory.CreateLiveResponse(liveResponse, "", HttpStatusCode.OK);
        }

        public LiveResponse UpdateLive(Live live)
        {
            liveResponse = new LiveResponse();

            if (live.id == 0)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, "live.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                liveResponse.live = liveDao.CreateLive(live);
            }
            catch (Exception ex)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return liveResponseFactory.CreateLiveResponse(liveResponse, "", HttpStatusCode.OK);
        }

        public LiveResponse DeleteLive(Live live)
        {
            liveResponse = new LiveResponse();

            if (live.id == 0)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, "live.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                liveDao.DeleteLive(live);
            }
            catch (Exception ex)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return liveResponseFactory.CreateLiveResponse(liveResponse, "", HttpStatusCode.OK);
        }
    }
}
