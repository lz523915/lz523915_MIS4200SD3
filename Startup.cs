using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lz523915_MIS4200.Startup))]
namespace lz523915_MIS4200
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
