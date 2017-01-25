using Newtonsoft.Json;

namespace Domena
{
    public class Kategorija
    {
        [JsonProperty(PropertyName = "id")]
        public virtual int idKategorija { get; set; }
        [JsonProperty(PropertyName = "name")]
        public virtual string naziv { get; set; }
    }

}