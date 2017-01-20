namespace Domena
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class Ucenik : Osoba
    {

        public Ucenik()
        {
            this.biljeske = new List<Biljeska>();
            this.izostanci = new List<Izostanak>();
            this.ocjene = new List<Ocjena>();
        }
        [JsonIgnore]
        public virtual ICollection<Biljeska> biljeske { get; set; }
        [JsonIgnore]
        public virtual ICollection<Izostanak> izostanci { get; set; }
        [JsonIgnore]
        public virtual ICollection<Ocjena> ocjene { get; set; }
        [JsonIgnore]
        public virtual Razred razred { get; set; }

    }

}
