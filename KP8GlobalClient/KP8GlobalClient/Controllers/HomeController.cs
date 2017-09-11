using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using KP8GlobalClient.Models;
using System.Security.Claims;

namespace KP8GlobalClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult _headerLinks()
        {
            return PartialView("_headerLinks");
        }
	}
}