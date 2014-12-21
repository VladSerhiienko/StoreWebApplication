using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCDecimalToFraction.Startup))]
namespace MVCDecimalToFraction
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
