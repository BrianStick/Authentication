using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Week_8_day_2.Startup))]
namespace Week_8_day_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
