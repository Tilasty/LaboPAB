using System.Runtime.Serialization;

namespace LaboPabSoap.Entities
{
    [DataContract]
    public class Department
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }