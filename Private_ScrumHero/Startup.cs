using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Private_ScrumHero.Startup))]
namespace Private_ScrumHero
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
