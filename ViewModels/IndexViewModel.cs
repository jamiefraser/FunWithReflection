using FunWithReflection.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithReflection.ViewModels
{
    public class IndexViewModel : IIndexViewModel
    {
        private IServiceCollection services;
        public IndexViewModel(IServiceCollection _services, IServiceProvider provider)
        {

            services = _services;
            //foreach (var s in services)
            //{
            //    Console.WriteLine($"There is a registered service of type with a servicetype of {s.ServiceType.Name}");
            //}
            foreach(var x in typeof(App).Assembly.CreatableTypes().EndingWith("Service"))
            {
                services.GetServiceInstanceAndExecuteMethod(provider, x.GetInterfaces()[0], "Refresh");
                //Console.WriteLine($"working with a type called {x.GetInterfaces()[0].Name}");
                //var s = services.Where(t => t.ServiceType.Equals(x.GetInterfaces()[0])).FirstOrDefault();
                //if(s != null)
                //{

                //    Console.WriteLine($"Found a type with the name {x.Name} - trying to do something with it");
                //    dynamic implementation = provider.GetRequiredService(s.ServiceType);
                //    Console.WriteLine($"The ImplementationType is {s.ImplementationType.Name}");
                //    implementation.Refresh();
                //    //dynamic svc = s;
                //    //svc.Refresh();
                //}
            }
        }
    }
}
