using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iVideo.Startup))]
namespace iVideo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
