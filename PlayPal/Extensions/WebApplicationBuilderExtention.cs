using Microsoft.CodeAnalysis.CSharp.Syntax;
using PlayPal.Core.Services;

namespace PlayPal.Extensions
{
    public static class WebApplicationBuilderExtention
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            var assembly = typeof(GameService).Assembly;

            var services = assembly.GetTypes()
                .Where(t => t.Name.EndsWith("Service"));

            foreach (var service in services)
            {
                string interfaceName = $"I{service.Name}";
                var interfaceType = service.GetInterface(interfaceName);

                if (interfaceType != null)
                {
                    builder.Services.AddScoped(interfaceType, service);
                }
            }
        }
    }
}
