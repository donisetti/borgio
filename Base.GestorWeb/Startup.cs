using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Base.GestorWeb.Startup))]
namespace Base.GestorWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);

        }


    }


}
