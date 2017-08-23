using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using KP8GlobalClient.Models;
using System.Security.Claims;

namespace KP8GlobalClient.Controllers
{
    [AllowAnonymous]
    public class IndexController : Controller
    {
        [HttpGet]
        public ActionResult Index() 
        {
            if (Request.GetOwinContext().Authentication.User.HasClaim(ClaimTypes.Authentication, "MLKP"))
                return RedirectToAction("Home", "Home");
            else
                return PartialView("Login");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult LogIn(LoginModel Login)
        { 
            try
            {
                if (!ModelState.IsValid)
                    return PartialView(Login); 

                var UserData = new LoginModel();
                var getInfo = new UserAdminLogin().getUserLogin();

                if (getInfo.Username == Login.Username.ToLower() &&
                    getInfo.Password == Login.Password)
                {
                    var userLogged = new ClaimsIdentity(new[] { new Claim(ClaimTypes.UserData, getInfo.Username),
                                                                new Claim(ClaimTypes.Authentication, "MLKP"),
                                                                new Claim(ClaimTypes.Role, getInfo.Role),
                                                                new Claim(ClaimTypes.GivenName, getInfo.FName)
                                                              }, "KP8GC");
                    this.Session["User"] = getInfo.FName;
                    this.Session["Branch"] = getInfo.Branch;
                    this.Session["Role"] = getInfo.Role;
                    this.Session["Server"] = getInfo.Server;
                    Request.GetOwinContext().Authentication.SignIn(userLogged);
                    return RedirectToAction("Home", "Home", getInfo);
                }
                else
                {
                    UserData.ErrorMessage = "Username and Password did not match";
                    return PartialView(UserData);
                }
            }
            catch (Exception)
            {

            }
            return PartialView();
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