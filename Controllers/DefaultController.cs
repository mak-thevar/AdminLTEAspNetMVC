using AspMVCAdminLTE.Infrastructure;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMVCAdminLTE.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ILogManager logger;
        public DefaultController(ILogManager log)
        {
            this.logger = log;
        }
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

        [HttpGet]
        public ActionResult ExceptionHandler()
        {
            logger.LogInfo(new Dictionary<string, string> { { "INFO", "Starting Info" } });
            logger.LogDebug(new { Info = "Extra info to be passed", type= "As an object type"});
            try
            {
                var number = 1000;
                var division = 1000;
                var result = 2 * 5 / (number % division);
            }
            catch (Exception ex)
            {
                logger.LogError("Error Log", ex);
            }

            return Json(new { message = "Logged all the error" }, behavior: JsonRequestBehavior.AllowGet);
        }
    }
}