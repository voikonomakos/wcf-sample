using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Lib;

namespace Client
{
    internal class SampleServiceProxy : ISampleService
    {
        private readonly Binding binding;
        private readonly EndpointAddress address;

        public SampleServiceProxy(Binding binding, EndpointAddress address)
        {
            this.binding = binding;
            this.address = address;
        }

        public SampleData Get(int id)
        {
            return Execute(client => client.Get(id));
        }

        public bool Update(SampleData data)
        {
            return Execute(client => client.Update(data));
        }

        private T Execute<T>(Func<SampleServiceClient, T> func)
        {
            SampleServiceClient client = new SampleServiceClient(binding, address);

            try
            {
                T result = func(client);
                client.Close();

                return result;
            }
            catch (TimeoutException ex)
            {
                client.Abort();
                throw;
            }
            catch (FaultException ex)
            {
                client.Abort();
                throw;
            }
            catch (CommunicationException ex)
            {
                client.Abort();
                throw;
            }
            catch (Exception ex)
            {
                client.Abort();
                throw;
            }
        }

        private void Execute(Action<SampleServiceClient> action)
        {
            Execute(client =>
            {
                action(client);
                return true;
            });
        }

        private class SampleServiceClient : ClientBase<ISampleService>, ISampleService
        {
            public SampleServiceClient(Binding binding, EndpointAddress address) : base(binding, address)
            {
            }

            public SampleData Get(int id)
            {
                return Channel.Get(id);
            }

            public bool Update(SampleData data)
            {
                return Channel.Update(data);
            }
        }
    }
}