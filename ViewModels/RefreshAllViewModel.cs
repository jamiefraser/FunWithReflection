using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithReflection.ViewModels
{
    public class RefreshAllViewModel : IRefreshAllViewModel
    {
        private IServiceCollection services;
        private IServiceProvider provider;
        public RefreshAllViewModel(IServiceCollection _services, IServiceProvider _provider)
        {
            services = _services;
            provider = _provider;
        }
        public void RefreshAll()
        {
            foreach (var x in typeof(App).Assembly.CreatableTypes().EndingWith("Service"))
            {
                services.GetServiceInstanceAndExecuteMethod(provider, x.GetInterfaces()[0], "Refresh");
            }
        }
    }
}
