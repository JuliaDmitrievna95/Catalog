using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FCatalog.Startup))]
namespace FCatalog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
