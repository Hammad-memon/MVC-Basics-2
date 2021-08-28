using fever.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAlong_Template.Controllers
{
    public class DoctorController : Controller
    {
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
    }
}
