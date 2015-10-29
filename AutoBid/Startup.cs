using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoBid.Startup))]
namespace AutoBid
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
