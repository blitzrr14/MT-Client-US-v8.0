using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace KP8GlobalClient.App_Start
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions { AuthenticationType = "KP8GC",
                                                                          LoginPath = new PathString("/"),
                                                                          CookieName = "KP8GC",
                                                                          LogoutPath = new PathString("/")
                                                                        });
        }
    }
}