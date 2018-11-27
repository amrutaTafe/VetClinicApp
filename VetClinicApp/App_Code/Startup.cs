using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VetClinicApp.Startup))]
namespace VetClinicApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
