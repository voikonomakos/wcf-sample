using System.ServiceModel;

namespace Lib
{
    [ServiceContract]
    public interface ISampleService
    {
        [OperationContract]
        SampleData Get(int id);

        [OperationContract]
        bool Update(SampleData data);
    }
}
