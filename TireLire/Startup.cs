using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TireLire.Startup))]
namespace TireLire
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
