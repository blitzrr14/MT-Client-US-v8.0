using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KP8GlobalClient.App_Start.StartUp))]
namespace KP8GlobalClient.App_Start
{
    public partial class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
