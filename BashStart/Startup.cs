using System.Web.Http;
using Owin;

namespace BashStart
{
    internal class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            StartCore.WebApiConfig.Register(config);

            appBuilder.UseWebApi(config);
        }
    }
}
