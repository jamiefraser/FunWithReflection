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

        }
    }
}
