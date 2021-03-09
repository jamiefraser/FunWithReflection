using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithReflection.Services
{
        public class AnotherService : ITestService<object>
        {
            public void Refresh()
            {
                Console.WriteLine("I'm refreshing from AnotherService!!!");
            }
        }
}
