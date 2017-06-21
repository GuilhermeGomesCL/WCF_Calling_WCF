using Service1;
using System;
using System.ServiceModel;

namespace RunService1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Service 1");

            var service1Host = new ServiceHost(typeof(Service1.Service1));
            service1Host.AddServiceEndpoint(typeof(IService1), new NetTcpBinding(), "net.tcp://localhost:10001/Service1/Service1/");
            service1Host.Open();

            while (true)
            {

            }
        }
    }
}
