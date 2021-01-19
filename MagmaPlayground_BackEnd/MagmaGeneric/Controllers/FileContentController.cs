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
    public class FileContentController : ControllerBase
    {
        private FileContentService fileContentService;
        private GenericResponseFactory genericResponseFactory;

        public FileContentController(MagmaGenericDbContext magmaGenericDbContext)
        {
            fileContentService = new FileContentService(magmaGenericDbContext);
            genericResponseFactory = new GenericResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetFileContentById(int id)
        {
            return genericResponseFactory.CreateGenericControllerResponse(fileContentService.GetFileContentById(id));
        }

        [HttpPost("create")]
        public ActionResult<string> CreateFileContent(FileContent fileContent)
        {
            return genericResponseFactory.CreateGenericControllerResponse(fileContentService.CreateFileContent(fileContent));
        }

        [HttpPost("update")]
        public ActionResult<string> UpdateFileContent(FileContent fileContent)
        {
            return genericResponseFactory.CreateGenericControllerResponse(fileContentService.UpdateFileContent(fileContent));
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteFileContent(FileContent fileContent)
        {
            return genericResponseFactory.CreateGenericControllerResponse(fileContentService.DeleteFileContent(fileContent));
        }
    }
}
