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
    public class FileTypeService
    {
        private FileTypeDao fileTypeDao;
        private GenericResponseFactory genericResponseFactory;
        private GenericResponse genericResponse;

        public FileTypeService(MagmaGenericDbContext magmaGenericDBContext)
        {
            fileTypeDao = new FileTypeDao(magmaGenericDBContext);
        }

        public GenericResponse GetFileTypeById(int id)
        {
            genericResponse = new GenericResponse();

            if (id == 0)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, "fileType.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                genericResponse.fileType = fileTypeDao.GetFileTypeById(id);
            }
            catch (Exception ex)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return genericResponseFactory.CreateGenericResponse(genericResponse, "", HttpStatusCode.OK);
        }

        public GenericResponse CreateFileType(FileType fileType)
        {
            genericResponse = new GenericResponse();

            if (fileType.id != 0)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, "fileType.id is not null", HttpStatusCode.BadRequest);
            }

            try
            {
                genericResponse.fileType = fileTypeDao.CreateFileType(fileType);
            }
            catch (Exception ex)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return genericResponseFactory.CreateGenericResponse(genericResponse, "", HttpStatusCode.OK);
        }

        public GenericResponse UpdateFileType(FileType fileType)
        {
            genericResponse = new GenericResponse();

            if (fileType.id == 0)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, "fileType.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                genericResponse.fileType = fileTypeDao.CreateFileType(fileType);
            }
            catch (Exception ex)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return genericResponseFactory.CreateGenericResponse(genericResponse, "", HttpStatusCode.OK);
        }

        public GenericResponse DeleteFileType(FileType fileType)
        {
            genericResponse = new GenericResponse();

            if (fileType.id == 0)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, "fileType.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                fileTypeDao.DeleteFileType(fileType);
            }
            catch (Exception ex)
            {
                return genericResponseFactory.CreateGenericResponse(genericResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return genericResponseFactory.CreateGenericResponse(genericResponse, "", HttpStatusCode.OK);
        }
    }
}
