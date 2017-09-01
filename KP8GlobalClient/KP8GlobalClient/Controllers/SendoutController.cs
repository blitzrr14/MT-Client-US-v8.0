using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KP8GlobalClient.Controllers
{
    public class SendoutController : Controller
    {
        //
        // GET: /Sendout/
        public ActionResult Index()
        {
            return PartialView();
        }
	}
}