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

        public FileController(MagmaGenericDbContext magmaGenericDbContext)
        {
            fileService = new FileService(magmaGenericDbContext);
        }

        [HttpGet("{id}")]
        public ActionResult<GenericResponse> GetFileById(int id)
        {
            return fileService.GetFileById(id);
        }

        [HttpPost("create")]
        public ActionResult<GenericResponse> CreateFile(File file)
        {
            return fileService.CreateFile(file);
        }

        [HttpPost("update")]
        public ActionResult<GenericResponse> UpdateFile(File file)
        {
            return fileService.UpdateFile(file);
        }

        [HttpDelete("{id}")]
        public ActionResult<GenericResponse> DeleteFile(File file)
        {
            return fileService.DeleteFile(file);
        }
    }
}
