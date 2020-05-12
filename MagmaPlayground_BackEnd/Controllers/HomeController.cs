using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MagmaPlayground_BackEnd.Controllers
{
    [Route("magma_api/{controller}")]
    public class HomeController : Controller
    {
        [HttpPost]
        public IActionResult Index()
        {
            return Ok("Home controller: OK");
        }
    }
}
