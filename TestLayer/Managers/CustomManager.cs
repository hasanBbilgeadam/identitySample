using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLayer.Services;

namespace TestLayer.Managers
{
    public class CustomManager : ICustomService
    {
        public void SayHello()
        {
            Console.WriteLine("merhaba dünya");
        }
    }  
    public class CustomManager2 : ICustomService2
    {
        public void SayHello()
        {
            Console.WriteLine("merhaba dünya 2");
        }
    }
}
