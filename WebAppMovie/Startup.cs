using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppMovie.Startup))]
namespace WebAppMovie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
