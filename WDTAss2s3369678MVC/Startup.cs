using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WDTAss2s3369678MVC.Startup))]
namespace WDTAss2s3369678MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
