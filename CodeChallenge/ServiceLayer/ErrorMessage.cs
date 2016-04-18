using System.Runtime.Serialization;

namespace CodeChallenge
{
    /// <summary>
    /// Intend to show Error Message, currently is not in use
    /// </summary>
    
    [DataContract]
    public class ErrorMessage
    {
        [DataMember]
        public string Message { get; set; } = "";
    }
}