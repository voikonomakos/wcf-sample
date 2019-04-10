using System;
using System.ServiceModel;
using Lib;

namespace Server
{
    internal class SampleServiceHost : IDisposable
    {
        private readonly ServiceHost serviceHost;

        public SampleServiceHost(string serviceUrl)
        {
            NetTcpBinding binding = new NetTcpBinding();

            Uri baseAddress = new Uri(serviceUrl);

            serviceHost = new ServiceHost(typeof(SampleService), baseAddress);

            serviceHost.AddServiceEndpoint(typeof(ISampleService), binding, baseAddress);

            serviceHost.Open();
        }

        public void Dispose()
        {
            serviceHost?.Close();
        }
    }
}
