using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebRss.Startup))]
namespace WebRss
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
