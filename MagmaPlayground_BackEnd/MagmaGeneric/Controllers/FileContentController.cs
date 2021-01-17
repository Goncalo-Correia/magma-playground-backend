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
    public class FileContentController : ControllerBase
    {
        private FileContentService fileContentService;

        public FileContentController(MagmaGenericDbContext magmaGenericDbContext)
        {
            fileContentService = new FileContentService(magmaGenericDbContext);
        }

        [HttpGet("{id}")]
        public ActionResult<GenericResponse> GetFileContentById(int id)
        {
            return fileContentService.GetFileContentById(id);
        }

        [HttpGet("create")]
        public ActionResult<GenericResponse> CreateFileContent(FileContent fileContent)
        {
            return fileContentService.CreateFileContent(fileContent);
        }

        [HttpPost("update")]
        public ActionResult<GenericResponse> UpdateFileContent(FileContent fileContent)
        {
            return fileContentService.UpdateFileContent(fileContent);
        }

        [HttpDelete("{id}")]
        public ActionResult<GenericResponse> DeleteFileContent(FileContent fileContent)
        {
            return fileContentService.DeleteFileContent(fileContent);
        }
    }
}
