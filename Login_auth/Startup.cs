using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Login_auth.Startup))]
namespace Login_auth
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
