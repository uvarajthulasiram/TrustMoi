using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrustMoi.Startup))]
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
