using MagmaPlayground_BackEnd.MagmaDaw.Daos;
using MagmaPlayground_BackEnd.MagmaDaw.Models;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaDaw.Services
{
    public class SynthesizerTypeService
    {
        private SynthesizerTypeDao synthesizerTypeDao;
        private DawResponseFactory dawResponseFactory;
        private DawResponse dawResponse;

        public SynthesizerTypeService(MagmaDawDbContext magmaDbContext)
        {
            synthesizerTypeDao = new SynthesizerTypeDao(magmaDbContext);
            dawResponseFactory = new DawResponseFactory();
        }

        public DawResponse GetSynthesizerTypeById(int id)
        {
            dawResponse = new DawResponse();

            if (id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: synthesizerType.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.synthesizerType = synthesizerTypeDao.GetSynthesizerTypeById(id);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            if (dawResponse.synthesizerType == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: synthesizerType not found", HttpStatusCode.NotFound);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse GetSynthesizerTypes()
        {
            dawResponse = new DawResponse();

            try
            {
                dawResponse.synthesizerTypes = synthesizerTypeDao.GetSynthesizerTypes();
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            if (dawResponse.synthesizerTypes == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: synthesizerTypes not found", HttpStatusCode.NotFound);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse CreateSynthesizerType(SynthesizerType synthesizerType)
        {
            dawResponse = new DawResponse();

            if (synthesizerType == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: synthesizerType is null", HttpStatusCode.BadRequest);
            }

            if (synthesizerType.id != 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: synthesizerType.id must be null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.synthesizerType = synthesizerTypeDao.CreateSynthesizerType(synthesizerType);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse UpdateSynthesizerType(SynthesizerType synthesizerType)
        {
            dawResponse = new DawResponse();

            if (synthesizerType == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: synthesizerType is null", HttpStatusCode.BadRequest);
            }

            if (synthesizerType.id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: synthesizerType.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.synthesizerType = synthesizerTypeDao.UpdateSynthesizerType(synthesizerType);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse DeleteSynthesizerType(int id)
        {
            dawResponse = new DawResponse();

            if (id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: synthesizerType.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                synthesizerTypeDao.DeleteSynthesizerType(GetSynthesizerTypeById(id).synthesizerType);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }
    }
}
