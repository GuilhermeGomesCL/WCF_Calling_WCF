using Service2;
using System;
using System.ServiceModel;

namespace Service1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string ExecuteService1(string message)
        {
            Console.WriteLine("Service 1 - Received message: " + message);

            string result = string.Empty;

            try
            {
                Console.WriteLine("Service 1 - Sent message: " + message);

                ChannelFactory<IService2> channelFactory2 = new ChannelFactory<IService2>(new NetTcpBinding());
                IService2 channel2 = channelFactory2.CreateChannel(new EndpointAddress("net.tcp://localhost:10002/Service2/Service2/"));
                result = channel2.ExecuteService2(message);

                Console.WriteLine("Service 1 - Got message: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on Service 1:\n" + ex.Message);
            }

            return result;
        }
    }
}
