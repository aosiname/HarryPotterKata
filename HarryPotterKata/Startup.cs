using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HarryPotterKata.Startup))]
namespace HarryPotterKata
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
