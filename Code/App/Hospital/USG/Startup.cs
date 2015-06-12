using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(USG.Startup))]


namespace USG
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}