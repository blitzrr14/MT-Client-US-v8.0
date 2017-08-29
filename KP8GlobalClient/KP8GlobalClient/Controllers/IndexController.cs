using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using KP8GlobalClient.Models;
using System.Security.Claims;

namespace KP8GlobalClient.Controllers
{
   [Authorize]
    public class IndexController : Controller
    {
       
        [HttpGet]
        [AllowAnonymous]
        public ActionResult LogIn() 
        {
            if (Request.GetOwinContext().Authentication.User.HasClaim(ClaimTypes.Authentication, "MLKP") && this.Session["User"] != null)
            //if (this.Session["User"] != null)
                return RedirectToAction("Home", "Home");
            else
                return View();
        }


        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult LoginUser(LoginModel Login)
        {
            if (!ModelState.IsValid)
                return PartialView(Login);
            else
            {
                var getInfo = new UserAdminLogin().getUserLogin();

                if (getInfo.Username == Login.Username.ToLower() && getInfo.Password == Login.Password)
                {
                    var userLogged = new ClaimsIdentity(new[] { new Claim(ClaimTypes.UserData, getInfo.Username),
                                                                new Claim(ClaimTypes.Authentication, "MLKP"),
                                                                new Claim(ClaimTypes.Role, getInfo.Role),
                                                                new Claim(ClaimTypes.GivenName, getInfo.FName)
                                                              }, "KP8GC");
                    Request.GetOwinContext().Authentication.SignIn(userLogged);

                    this.Session["User"] = getInfo.FName;
                    this.Session["Branch"] = getInfo.Branch;
                    this.Session["Role"] = getInfo.Role;
                    this.Session["Server"] = getInfo.Server;

                    return RedirectToAction("Index", "Sendout");
                }
                else
                    Login.ErrorMessage = "Username and Password did not match";

            }
            return PartialView("LogIn", Login);
        }

        [HttpGet]
        public ActionResult Logout()
        {            
            Request.GetOwinContext().Authentication.SignOut("MLKP");            
            Session.Clear();
            return RedirectToAction("Index", "Index");
        }
	}
}