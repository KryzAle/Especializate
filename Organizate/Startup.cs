using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Organizate.Startup))]
namespace Organizate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
