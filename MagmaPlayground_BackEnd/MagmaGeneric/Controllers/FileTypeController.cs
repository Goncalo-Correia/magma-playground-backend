using MagmaPlayground_BackEnd.MagmaDB.MagmaGeneric;
using MagmaPlayground_BackEnd.MagmaGeneric.Response;
using MagmaPlayground_BackEnd.MagmaGeneric.Services;
using MagmaPlayground_BackEnd.Models.MagmaGeneric;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaGeneric.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class FileTypeController : ControllerBase
    {
        private FileTypeService fileTypeService;
        private GenericResponseFactory genericResponseFactory;

        public FileTypeController(MagmaGenericDbContext magmaGenericDbContext)
        {
            fileTypeService = new FileTypeService(magmaGenericDbContext);
            genericResponseFactory = new GenericResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetFileContentById(int id)
        {
            return genericResponseFactory.CreateGenericControllerResponse(fileTypeService.GetFileTypeById(id));
        }

        [HttpPost("create")]
        public ActionResult<string> CreateFileContent(FileType fileType)
        {
            return genericResponseFactory.CreateGenericControllerResponse(fileTypeService.CreateFileType(fileType));
        }

        [HttpPost("update")]
        public ActionResult<string> UpdateFileContent(FileType fileType)
        {
            return genericResponseFactory.CreateGenericControllerResponse(fileTypeService.UpdateFileType(fileType));
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteFileContent(FileType fileType)
        {
            return genericResponseFactory.CreateGenericControllerResponse(fileTypeService.DeleteFileType(fileType));
        }
    }
}
