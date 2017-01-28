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
        public virtual ICollection<Biljeska> biljeske { get; set; }
        public virtual ICollection<Izostanak> izostanci { get; set; }
        public virtual ICollection<Ocjena> ocjene { get; set; }
        public virtual Razred razred { get; set; }

    }

}
