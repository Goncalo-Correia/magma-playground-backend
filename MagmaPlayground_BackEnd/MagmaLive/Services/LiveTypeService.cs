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
    public class LiveTypeService
    {
        private LiveTypeDao liveTypeDao;
        private LiveResponseFactory liveResponseFactory;
        private LiveResponse liveResponse;

        public LiveTypeService(MagmaLiveDbContext magmaLiveDbContext)
        {
            liveTypeDao = new LiveTypeDao(magmaLiveDbContext);
        }

        public LiveResponse GetLiveFileById(int id)
        {
            liveResponse = new LiveResponse();

            if (id == 0)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, "liveType.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                liveResponse.liveType = liveTypeDao.GetLiveTypeById(id);
            }
            catch (Exception ex)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return liveResponseFactory.CreateLiveResponse(liveResponse, "", HttpStatusCode.OK);
        }

        public LiveResponse CreateLiveFile(LiveType liveType)
        {
            liveResponse = new LiveResponse();

            if (liveType.id != 0)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, "liveFile.id is not null", HttpStatusCode.BadRequest);
            }

            try
            {
                liveResponse.liveType = liveTypeDao.CreateLiveType(liveType);
            }
            catch (Exception ex)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return liveResponseFactory.CreateLiveResponse(liveResponse, "", HttpStatusCode.OK);
        }

        public LiveResponse UpdateLiveFile(LiveType liveType)
        {
            liveResponse = new LiveResponse();

            if (liveType.id == 0)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, "liveFile.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                liveResponse.liveType = liveTypeDao.CreateLiveType(liveType);
            }
            catch (Exception ex)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return liveResponseFactory.CreateLiveResponse(liveResponse, "", HttpStatusCode.OK);
        }

        public LiveResponse DeleteLiveFile(LiveType liveType)
        {
            liveResponse = new LiveResponse();

            if (liveType.id == 0)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, "liveFile.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                liveTypeDao.DeleteLiveType(liveType);
            }
            catch (Exception ex)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return liveResponseFactory.CreateLiveResponse(liveResponse, "", HttpStatusCode.OK);
        }
    }
}
