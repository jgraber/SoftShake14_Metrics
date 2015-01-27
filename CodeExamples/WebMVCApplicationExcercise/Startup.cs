using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMVCApplicationExcercise.Startup))]
namespace WebMVCApplicationExcercise
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
