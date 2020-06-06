using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagmaPlayground_BackEnd.Factories;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using Microsoft.AspNetCore.Mvc;

namespace MagmaPlayground_BackEnd.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class PlaygroundController : ControllerBase
    {
        private MagmaDbContext magmaDbContext;

        public PlaygroundController(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

    }
}