using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperBorgio.GestorWeb.Startup))]
namespace SuperBorgio.GestorWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);

        }


    }


}
