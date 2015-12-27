using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppWebEncodageEmploi.Startup))]
namespace AppWebEncodageEmploi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
