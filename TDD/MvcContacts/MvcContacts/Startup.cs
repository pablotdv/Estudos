using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcContacts.Startup))]
namespace MvcContacts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
