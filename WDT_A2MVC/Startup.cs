using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WDT_A2MVC.Startup))]
namespace WDT_A2MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
