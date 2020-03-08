using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(jkMovie.Startup))]
namespace jkMovie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
