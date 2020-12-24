using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(БИПиТ10.Startup))]
namespace БИПиТ10
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
