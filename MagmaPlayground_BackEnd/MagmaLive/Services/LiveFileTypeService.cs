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
    public class LiveFileTypeService
    {
        private LiveFileTypeDao liveFileTypeDao;
        private LiveResponseFactory liveResponseFactory;
        private LiveResponse liveResponse;

        public LiveFileTypeService(MagmaLiveDbContext magmaLiveDbContext)
        {
            liveFileTypeDao = new LiveFileTypeDao(magmaLiveDbContext);
            liveResponseFactory = new LiveResponseFactory();
        }

        public LiveResponse GetLiveFileTypeById(int id)
        {
            liveResponse = new LiveResponse();

            if (id == 0)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, "liveFileType.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                liveResponse.liveFileType = liveFileTypeDao.GetLiveFileTypeById(id);
            }
            catch (Exception ex)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return liveResponseFactory.CreateLiveResponse(liveResponse, "", HttpStatusCode.OK);
        }

        public LiveResponse CreateLiveFileType(LiveFileType liveFileType)
        {
            liveResponse = new LiveResponse();

            if (liveFileType.id != 0)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, "liveFileType.id is not null", HttpStatusCode.BadRequest);
            }

            try
            {
                liveResponse.liveFileType = liveFileTypeDao.CreateLiveFileType(liveFileType);
            }
            catch (Exception ex)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return liveResponseFactory.CreateLiveResponse(liveResponse, "", HttpStatusCode.OK);
        }

        public LiveResponse UpdateLiveFileType(LiveFileType liveFileType)
        {
            liveResponse = new LiveResponse();

            if (liveFileType.id == 0)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, "liveFileType.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                liveResponse.liveFileType = liveFileTypeDao.CreateLiveFileType(liveFileType);
            }
            catch (Exception ex)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return liveResponseFactory.CreateLiveResponse(liveResponse, "", HttpStatusCode.OK);
        }

        public LiveResponse DeleteLiveFileType(LiveFileType liveFileType)
        {
            liveResponse = new LiveResponse();

            if (liveFileType.id == 0)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, "liveFileType.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                liveFileTypeDao.DeleteLiveFileType(liveFileType);
            }
            catch (Exception ex)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return liveResponseFactory.CreateLiveResponse(liveResponse, "", HttpStatusCode.OK);
        }
    }
}
