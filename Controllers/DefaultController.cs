using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMVCAdminLTE.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdvancedForm()
        {
            return View();
        }

        public ActionResult SimpleTables()
        {
            return View();
        }

        public ActionResult SimpleForm()
        {
            return View();
        }
    }
}