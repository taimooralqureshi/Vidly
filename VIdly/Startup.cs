using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VIdly.Startup))]
namespace VIdly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
