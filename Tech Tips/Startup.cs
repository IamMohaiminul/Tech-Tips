using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tech_Tips.Startup))]
namespace Tech_Tips
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
