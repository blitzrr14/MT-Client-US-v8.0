using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace KP8GlobalClient
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            //app.UseCookieAuthentication(new CookieAuthenticationOptions { AuthenticationType = "KP8GC",
            //                                                              LoginPath = new PathString("/"),
            //                                                              CookieName = "KP8GC",
            //                                                              LogoutPath = new PathString("/")
            //                                                            });

            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Index/LogIn")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

        }
    }
}