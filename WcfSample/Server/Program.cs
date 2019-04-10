using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string serviceUrl = System.Configuration.ConfigurationManager.AppSettings["ServiceUrl"];
                var host = new SampleServiceHost(serviceUrl);

                Console.WriteLine("Press enter to exit..");
                Console.ReadLine();

                host.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
