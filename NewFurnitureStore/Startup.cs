using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewFurnitureStore.Startup))]
namespace NewFurnitureStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
