using System;

namespace Service2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service2 : IService2
    {
        public string ExecuteService2(string message)
        {
            Console.WriteLine("Service 2 - Received message: " + message);

            string result = "WELCOME ";

            try
            {
                result += message;

                Console.WriteLine("Service 2 - Sent message: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on Service 2:\n" + ex.Message);
            }

            return result;
        }
    }
}
