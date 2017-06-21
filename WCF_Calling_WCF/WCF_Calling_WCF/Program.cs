using Service1;
using Service2;
using System;
using System.ServiceModel;

namespace WCF_Calling_WCF
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IService1> directChannelFactory1 = new ChannelFactory<IService1>(new NetTcpBinding());
            IService1 directChannel1 = directChannelFactory1.CreateChannel(new EndpointAddress("net.tcp://localhost:10001/Service1/Service1/"));
            Console.WriteLine("Direct Call Service 1 which calls Service 2: " + directChannel1.ExecuteService1("TesteA"));

            ChannelFactory<IService2> directChannelFactory2 = new ChannelFactory<IService2>(new NetTcpBinding());
            IService2 directChannel2 = directChannelFactory2.CreateChannel(new EndpointAddress("net.tcp://localhost:10002/Service2/Service2/"));
            Console.WriteLine("Direct Call Service 2: " + directChannel2.ExecuteService2("TesteB"));

            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Main Window - Calling Service 1 which calls Service 2");

            string message = Console.ReadLine();
            bool continueLoop = true;

            while (continueLoop)
            {
                try
                {
                    Console.WriteLine("Main - Sent message: " + message);
                    ChannelFactory<IService1> channelFactory1 = new ChannelFactory<IService1>(new NetTcpBinding());
                    IService1 channel1 = channelFactory1.CreateChannel(new EndpointAddress("net.tcp://localhost:10001/Service1/Service1/"));
                    Console.WriteLine("Main - Received message: " + channel1.ExecuteService1(message));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error on Main:\n" + ex.Message);
                }

                message = Console.ReadLine();

                if (string.Equals(message, "exit"))
                {
                    continueLoop = false;
                }
            }
        }
    }
}
