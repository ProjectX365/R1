using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FundRaiser.UI.Startup))]
namespace FundRaiser.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
