using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bewander.Startup))]
namespace Bewander
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
