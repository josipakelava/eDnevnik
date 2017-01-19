namespace Api.Models
{
    using System.Collections.Generic;

    public partial class Ucenik : Osoba
    {

        public Ucenik()
        {
            this.biljeske = new HashSet<Biljeska>();
            this.izostanci = new HashSet<Izostanak>();
            this.ocjene = new HashSet<Ocjena>();
        }

        public virtual ICollection<Biljeska> biljeske { get; set; }
        public virtual ICollection<Izostanak> izostanci { get; set; }
        public virtual ICollection<Ocjena> ocjene { get; set; }
        public virtual Razred razred { get; set; }

    }

}
