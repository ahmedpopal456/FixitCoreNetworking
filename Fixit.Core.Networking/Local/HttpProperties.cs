using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fixit.Core.Networking.Local
{
    [DataContract]
    public class HttpProperties
    {
        [DataMember]
        public IList<HeaderDto> Headers { get; set; }
    }
}
