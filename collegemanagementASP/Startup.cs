using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(collegemanagementASP.Startup))]
namespace collegemanagementASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
