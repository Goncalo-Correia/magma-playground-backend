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
    public class FileContentService
    {
        private FileContentDao fileContentDao;
        private GenericResponseFactory genericResponseFactory;
        private GenericResponse genericResponse;

        public FileContentService(MagmaGenericDbContext magmaGenericDBContext)
        {
            fileContentDao = new FileContentDao(magmaGenericDBContext);
        }

        public GenericResponse GetFileContentById(int id)
        {
            genericResponse = new GenericResponse();

            if (id == 0)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, "fileContent.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                genericResponse.fileContent = fileContentDao.GetFileContentById(id);
            }
            catch (Exception ex)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return genericResponseFactory.CreateGenericResponse(genericResponse, "", HttpStatusCode.OK);
        }

        public GenericResponse CreateFileContent(FileContent fileContent)
        {
            genericResponse = new GenericResponse();

            if (fileContent.id != 0)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, "fileContent.id is not null", HttpStatusCode.BadRequest);
            }

            try
            {
                genericResponse.fileContent = fileContentDao.CreateFileContent(fileContent);
            }
            catch (Exception ex)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return genericResponseFactory.CreateGenericResponse(genericResponse, "", HttpStatusCode.OK);
        }

        public GenericResponse UpdateFileContent(FileContent fileContent)
        {
            genericResponse = new GenericResponse();

            if (fileContent.id == 0)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, "fileContent.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                genericResponse.fileContent = fileContentDao.CreateFileContent(fileContent);
            }
            catch (Exception ex)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return genericResponseFactory.CreateGenericResponse(genericResponse, "", HttpStatusCode.OK);
        }

        public GenericResponse DeleteFileContent(FileContent fileContent)
        {
            genericResponse = new GenericResponse();

            if (fileContent.id == 0)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, "fileContent.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                fileContentDao.DeleteFileContent(fileContent);
            }
            catch (Exception ex)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return genericResponseFactory.CreateGenericResponse(genericResponse, "", HttpStatusCode.OK);
        }
    }
}
