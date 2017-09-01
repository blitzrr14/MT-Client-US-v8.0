using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using KP8GlobalClient.Models;

namespace KP8GlobalClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            //LoginModel Login = new LoginModel { FName = this.Session["User"].ToString(),
            //                                    Branch = this.Session["Bracnh"].ToString(),
            //                                    Role = this.Session["Role"].ToString(),
            //                                    Server = this.Session["Server"].ToString()
            //                                  };
            if (this.Session["User"] == null)
            {
                return RedirectToAction("LogIn", "Index");
            }
            else { 
            return View(new LoginModel { FName = this.Session["User"].ToString(),
                                         Branch = this.Session["Bracnh"].ToString(),
                                         Role = this.Session["Role"].ToString(),
                                         Server = this.Session["Server"].ToString()
                                       });
            }
        }
	}
}