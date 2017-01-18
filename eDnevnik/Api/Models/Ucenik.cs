namespace Api.Models
{
    using System.Collections.Generic;

    public partial class Ucenik : Osoba
    {

        public Ucenik()
        {
            this.biljeske = new HashSet<imaBiljesku>();
            this.izostanci = new HashSet<imaIzostanak>();
            this.ocjene = new HashSet<imaOcjenu>();
        }

        public virtual ICollection<imaBiljesku> biljeske { get; set; }
        public virtual ICollection<imaIzostanak> izostanci { get; set; }
        public virtual ICollection<imaOcjenu> ocjene { get; set; }
        public virtual Osoba osoba { get; set; }
        public virtual Razred razred { get; set; }
    }

}
