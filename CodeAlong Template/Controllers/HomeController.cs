using CodeAlong_Template.Models;
using fever.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAlong_Template.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Project()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }


        [Route("/FeverChecker")]
        [HttpGet]
        public ActionResult FeverChecker()
        {
            ViewData["Fever"] = "";
            ViewData["shypothermia"] = "";
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/FeverChecker")]
        public ActionResult FeverChecker(Fever model)
        {
            if (model.Unit == "Fahrenheit")
            {
                if (model.CheckFever >= 99)
                {
                    ViewData["Message"] = "You have fever ";
                }
                else
                {
                    ViewData["Message"] = "You have not  fever ";
                    if (model.Ishypothermia && (model.CheckFever <= 95))
                    {
                        ViewData["shypothermia"] = "but hypothermia";
                    }
                    else
                    {
                        ViewData["shypothermia"] = "";

                    }
                }
            }
            else
            {
                if (model.CheckFever >= 38)
                {
                    ViewData["Message"] = "You have fever ";
                }
                else
                {
                    ViewData["Message"] = "You have not  fever ";
                    if (model.Ishypothermia && (model.CheckFever <= 35))
                    {
                        ViewData["shypothermia"] = "but hypothermia";
                    }
                    else
                    {
                        ViewData["shypothermia"] = "";
                    }

                }

            }
            return View();
        }
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
