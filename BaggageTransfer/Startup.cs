using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BaggageTransfer.Startup))]
namespace BaggageTransfer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
