using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(APPBIBLIOTECA.Startup))]
namespace APPBIBLIOTECA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
