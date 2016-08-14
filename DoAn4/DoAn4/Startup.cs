using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoAn4.Startup))]
namespace DoAn4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
