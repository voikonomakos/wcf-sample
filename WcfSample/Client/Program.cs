using System;
using System.ServiceModel;
using Lib;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string serviceUrl = System.Configuration.ConfigurationManager.AppSettings["ServiceUrl"];

                EndpointAddress address = new EndpointAddress(serviceUrl);
                NetTcpBinding binding = new NetTcpBinding();

                SampleServiceProxy serviceProxy = new SampleServiceProxy(binding, address);

                SampleData sampleData = serviceProxy.Get(1);
                Console.WriteLine(sampleData);

                bool result = serviceProxy.Update(sampleData);
                Console.WriteLine(result);

                Console.WriteLine("Press enter to exit...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
