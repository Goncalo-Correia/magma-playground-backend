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
    public class FileController : ControllerBase
    {
        private FileService fileService;
        private GenericResponseFactory genericResponseFactory;

        public FileController(MagmaGenericDbContext magmaGenericDbContext)
        {
            fileService = new FileService(magmaGenericDbContext);
            genericResponseFactory = new GenericResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetFileById(int id)
        {
            return genericResponseFactory.CreateGenericControllerResponse(fileService.GetFileById(id));
        }

        [HttpPost("create")]
        public ActionResult<string> CreateFile(File file)
        {
            return genericResponseFactory.CreateGenericControllerResponse(fileService.CreateFile(file));
        }

        [HttpPost("update")]
        public ActionResult<string> UpdateFile(File file)
        {
            return genericResponseFactory.CreateGenericControllerResponse(fileService.UpdateFile(file));
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteFile(File file)
        {
            return genericResponseFactory.CreateGenericControllerResponse(fileService.DeleteFile(file));
        }
    }
}
