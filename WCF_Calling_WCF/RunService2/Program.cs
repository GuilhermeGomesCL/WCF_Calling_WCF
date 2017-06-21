using Service2;
using System;
using System.ServiceModel;

namespace RunService2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Service 2");

            var service2Host = new ServiceHost(typeof(Service2.Service2));
            service2Host.AddServiceEndpoint(typeof(IService2), new NetTcpBinding(), "net.tcp://localhost:10002/Service2/Service2/");
            service2Host.Open();

            while (true)
            {

            }
        }
    }
}
