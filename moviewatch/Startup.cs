using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(moviewatch.Startup))]
namespace moviewatch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
