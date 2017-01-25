using Newtonsoft.Json;

namespace Domena
{
    public class Mjesto
    {
        [JsonProperty(PropertyName = "id")]
        public virtual int idMjesto { get; set; }
        [JsonProperty(PropertyName = "name")]
        public virtual string ime { get; set; }
    }


}
