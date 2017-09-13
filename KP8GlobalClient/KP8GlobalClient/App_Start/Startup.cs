using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using System;
using Owin;

namespace KP8GlobalClient.App_Start
{
    public partial class StartUp
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "KP8GC",
                LoginPath = new PathString("/"),
                CookieName = "KP8GC",
                LogoutPath = new PathString("/"),
                ExpireTimeSpan = TimeSpan.FromMinutes(10),
            });

            // Enable the application to use a cookie to store information for the signed in user
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            //    LoginPath = new PathString("/Index/LogIn")
            //});
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

        }
    }
}