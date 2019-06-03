using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sprint_13_mvc.Startup))]
namespace Sprint_13_mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
