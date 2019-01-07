using Microsoft.Owin;
using Owin;
using WebApplication1.SingalIRTest;

[assembly: OwinStartupAttribute(typeof(WebApplication1.Startup))]

namespace WebApplication1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
            app.MapSignalR();
            app.MapSignalR<OrderConnection>("/Connections/OrderConnection");
        }
    }
}
