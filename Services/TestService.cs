using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithReflection.Services
{
    public class TestService : ITestService<string>
    {
        public void Refresh()
        {
            Console.WriteLine("I'm Refreshing from the Test Service!!");
        }
    }
}
