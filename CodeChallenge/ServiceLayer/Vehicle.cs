using System.Runtime.Serialization;


namespace CodeChallenge
{
    /// <summary>
    /// DataContract
    /// NOTE: 
    /// Must Implement IItemWithId or can not be process by vehicle repository
    /// </summary>
    [DataContract]
    public class Vehicle : IItemWithId
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public string Make { get; set; }
        [DataMember]
        public string Model { get; set; }
    }
}