using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LaunSys.Startup))]
namespace LaunSys
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
