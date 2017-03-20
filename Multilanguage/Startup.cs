using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Multilanguage.Startup))]
namespace Multilanguage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
