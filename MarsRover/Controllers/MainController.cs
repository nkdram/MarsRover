using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarsRover
{
    public class MainController : Controller
    {
        //
        // GET: /Main/

        public ActionResult Index()
        {

            ViewBag.Message = "Mars Rover";
            return View();
        }

    }
}
