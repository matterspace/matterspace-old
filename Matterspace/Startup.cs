using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Matterspace.Startup))]
namespace Matterspace
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
