using Lib;

namespace Server
{
    internal class SampleService : ISampleService
    {
        public SampleData Get(int Id)
        {
            return new SampleData(1, "some value");
        }

        public bool Update(SampleData data)
        {
            return true;
        }
    }
}
