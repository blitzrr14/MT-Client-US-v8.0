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
        
        public ActionResult Home(HomeModel data)
        {
            //LoginModel Login = new LoginModel { FName = this.Session["User"].ToString(),
            //                                    Branch = this.Session["Bracnh"].ToString(),
            //                                    Role = this.Session["Role"].ToString(),
            //                                    Server = this.Session["Server"].ToString()
            //                                  };
            //ViewBag.Title = "Home";
            if (data.isLoggedIn)
                if (Request.GetOwinContext().Authentication.User.HasClaim(ClaimTypes.Authentication, "MLKP"))
                    return View();
                else
                    return RedirectToAction("Index", "Index");
            else
                return PartialView();
        }

        public ActionResult _headerLinks()
        {
            return PartialView("_headerLinks");
        }
	}
}