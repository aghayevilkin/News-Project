using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            TempData["Controller"] = "News";
            return View();
        }
        


        public IActionResult Details()
        {
            TempData["Controller"] = "NewsDetails";
            return View();
        }
    }
}
