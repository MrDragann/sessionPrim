using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Session.Startup))]
namespace Session
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
