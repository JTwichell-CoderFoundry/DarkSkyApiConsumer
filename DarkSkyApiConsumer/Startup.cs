using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DarkSkyApiConsumer.Startup))]
namespace DarkSkyApiConsumer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
