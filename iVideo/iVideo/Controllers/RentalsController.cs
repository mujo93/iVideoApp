using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iVideo.Controllers
{
    public class RentalsController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        // GET: Rentals
        public ActionResult New()
        {
            return View();
        }
    }
}