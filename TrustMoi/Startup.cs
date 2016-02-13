using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrustMoi.Startup))]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Web.config", Watch = true)]
namespace TrustMoi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
