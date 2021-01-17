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

        public FileTypeController(MagmaGenericDbContext magmaGenericDbContext)
        {
            fileTypeService = new FileTypeService(magmaGenericDbContext);
        }

        [HttpGet("{id}")]
        public ActionResult<GenericResponse> GetFileContentById(int id)
        {
            return fileTypeService.GetFileTypeById(id);
        }

        [HttpPost("create")]
        public ActionResult<GenericResponse> CreateFileContent(FileType fileType)
        {
            return fileTypeService.CreateFileType(fileType);
        }

        [HttpPost("update")]
        public ActionResult<GenericResponse> UpdateFileContent(FileType fileType)
        {
            return fileTypeService.UpdateFileType(fileType);
        }

        [HttpDelete("{id}")]
        public ActionResult<GenericResponse> DeleteFileContent(FileType fileType)
        {
            return fileTypeService.DeleteFileType(fileType);
        }
    }
}
