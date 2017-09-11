using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using KP8GlobalClient.Models;
using System.Security.Claims;
using AESEncrypt;

namespace KP8GlobalClient.Controllers
{
   [Authorize]
    public class IndexController : Controller
    {
        //private AESEncryption encdata = new AESEncryption();
        //private String encStringKey = "B905BD7BFBD902DCB115B327F9018CEA";
        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index() 
        {
            if (Request.GetOwinContext().Authentication.User.HasClaim(ClaimTypes.Authentication, "MLKP"))// && theUser != string.Empty)
                return View("Home");
            else
                return View("LogIn");
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult LogIn(LoginModel Login)
        {
            if (ModelState.IsValid)
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

                    return PartialView("Home");
                }
                else
                    Login.ErrorMessage = "Username and Password did not match";
            }
            return PartialView(Login);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("KP8GC");            
            Session.Clear();
            return RedirectToAction("Index", "Index");
        }
	}
}