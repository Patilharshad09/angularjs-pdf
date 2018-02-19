using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RndApp.Controllers
{
    public class BusinessRulesController : Controller
    {
        //
        // GET: /BusinessRules/

        public ActionResult RiskScore()
        {
            return View();
        }
        public ActionResult AppScore()
        {
            return View();
        }

        public ActionResult CardSales()
        {
            return View();
        }

        public ActionResult ProgressTracker()
        {
            return View();
        }


    }
}
