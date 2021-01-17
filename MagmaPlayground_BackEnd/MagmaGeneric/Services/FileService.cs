using MagmaPlayground_BackEnd.MagmaDB.MagmaGeneric;
using MagmaPlayground_BackEnd.MagmaGeneric.Daos;
using MagmaPlayground_BackEnd.MagmaGeneric.Response;
using MagmaPlayground_BackEnd.Models.MagmaGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaGeneric.Services
{
    public class FileService
    {
        private FileDao fileDao;
        private GenericResponseFactory genericResponseFactory;
        private GenericResponse genericResponse;

        public FileService(MagmaGenericDbContext magmaGenericDBContext)
        {
            fileDao = new FileDao(magmaGenericDBContext);
            genericResponseFactory = new GenericResponseFactory();
        }

        public GenericResponse GetFileById(int id)
        {
            genericResponse = new GenericResponse();

            if (id == 0)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, "file.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                genericResponse.file = fileDao.GetFileById(id);
            }
            catch (Exception ex)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return genericResponseFactory.CreateGenericResponse(genericResponse, "", HttpStatusCode.OK);
        }

        public GenericResponse CreateFile(File file)
        {
            genericResponse = new GenericResponse();

            if (file.id != 0)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, "file.id is not null", HttpStatusCode.BadRequest);
            }

            try
            {
                genericResponse.file = fileDao.CreateFile(file);
            }
            catch (Exception ex)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return genericResponseFactory.CreateGenericResponse(genericResponse, "", HttpStatusCode.OK);
        }

        public GenericResponse UpdateFile(File file)
        {
            genericResponse = new GenericResponse();

            if (file.id == 0)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, "file.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                genericResponse.file = fileDao.CreateFile(file);
            }
            catch (Exception ex)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return genericResponseFactory.CreateGenericResponse(genericResponse, "", HttpStatusCode.OK);
        }

        public GenericResponse DeleteFile(File file)
        {
            genericResponse = new GenericResponse();

            if (file.id == 0)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, "file.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                fileDao.DeleteFile(file);
            }
            catch (Exception ex)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return genericResponseFactory.CreateGenericResponse(genericResponse, "", HttpStatusCode.OK);
        }
    }
}
