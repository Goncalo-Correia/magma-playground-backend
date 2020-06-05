using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MagmaPlayground_BackEnd.Controllers
{
    public class PlaygroundController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}