using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KP8GlobalClient.Startup))]
namespace KP8GlobalClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
