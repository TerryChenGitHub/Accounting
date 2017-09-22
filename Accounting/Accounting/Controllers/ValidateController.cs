using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accounting.Controllers
{
    public class ValidateController : Controller
    {
        // GET: Validate
        public ActionResult CheckAccountDate(DateTime AccountDate)
        {
            bool isValidate = AccountDate < DateTime.Now;
            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }
    }
}