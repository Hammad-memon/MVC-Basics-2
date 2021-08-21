using fever.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fever.Controllers
{
    public class Doctor : Controller
    {


        [Route("FeverCheck")]
        [HttpGet]
        public ActionResult FeverChecker()
        {
            ViewData["Fever"] = "";
            ViewData["shypothermia"] = "";
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("FeverCheck")]
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