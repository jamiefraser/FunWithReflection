using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FunWithReflection
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            foreach(var t in typeof(App).Assembly.CreatableTypes().EndingWith("ViewModel"))
            {
                Console.WriteLine($"Registering type {t.Name} implementing interface {t.GetInterfaces()[0].Name} with DI");
                builder.Services.AddSingleton(t.GetInterfaces()[0],t);
            }
            foreach(var t in typeof(App).Assembly.CreatableTypes().EndingWith("Service"))
            {
                Console.WriteLine($"Registering type {t.Name} implementing interface {t.GetInterfaces()[0].Name} with DI");
                builder.Services.AddSingleton(t.GetInterfaces()[0], t);
            }
            builder.Services.AddSingleton<IServiceCollection>(builder.Services);
            await builder.Build().RunAsync();
        }
    }
}
