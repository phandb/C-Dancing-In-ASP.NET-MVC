using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PatientApplication.Startup))]
namespace PatientApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
