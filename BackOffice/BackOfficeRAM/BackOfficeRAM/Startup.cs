using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BackOfficeRAM.Startup))]
namespace BackOfficeRAM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
