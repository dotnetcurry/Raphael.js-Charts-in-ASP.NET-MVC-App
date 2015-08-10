using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rephael_Chart.Startup))]
namespace Rephael_Chart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
