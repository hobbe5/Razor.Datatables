using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Razor.Datatables.Web.Startup))]
namespace Razor.Datatables.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
