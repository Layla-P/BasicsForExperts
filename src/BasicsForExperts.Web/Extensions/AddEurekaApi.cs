using Steeltoe.Discovery;
using Steeltoe.Discovery.Eureka;

namespace BasicsForExperts.Web.Extensions
{
    public static partial class WebApplicationExtensions
    {
        public static WebApplication AddEurekaApi(this WebApplication webApp)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                var discoveryClient = scope.ServiceProvider.GetRequiredService<IDiscoveryClient>() as DiscoveryClient;
                var apps = discoveryClient.Applications.GetRegisteredApplications();
                List<string> list = new();
                foreach (var app in apps)
                { 
                    list.Add(app.Name);
                }

                webApp.MapGet("/ShowRegisteredApps", () => new { list });

                
            }
            return webApp;
        }
    }
}
