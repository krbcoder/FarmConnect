using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExpeditionHackathon.Startup))]
namespace ExpeditionHackathon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
