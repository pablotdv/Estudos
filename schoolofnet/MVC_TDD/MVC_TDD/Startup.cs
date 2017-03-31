using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_TDD.Startup))]
namespace MVC_TDD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
