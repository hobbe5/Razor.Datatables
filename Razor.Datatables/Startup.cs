using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Razor.Datatables.Startup))]
namespace Razor.Datatables
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
