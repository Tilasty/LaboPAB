using System.Runtime.Serialization;

namespace LaboPabSoap.Entities
{
    [DataContract]
    public class Project
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }
    }
}