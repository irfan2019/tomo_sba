using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoginSystem2.Startup))]
namespace LoginSystem2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
