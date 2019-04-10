using System.Runtime.Serialization;

namespace Lib
{
    [DataContract]
    public class SampleData
    {
        private SampleData()
        {
        }

        public SampleData(int id, string value)
        {
            Id = id;
            Value = value;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Value)}: {Value}";
        }
    }
}
