using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ECommerce.GUI.Startup))]
namespace ECommerce.GUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
