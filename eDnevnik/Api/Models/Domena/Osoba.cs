namespace Api.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;

    public abstract class Osoba
    {
        public virtual int idOsoba { get; set; }
        public virtual string ime { get; set; }
        public virtual string prezime { get; set; }
        public virtual DateTime datumRodjenja { get; set; }
        public virtual string adresa { get; set; }
        public virtual string OIB { get; set; }
        public virtual string email { get; set; }
        public virtual string password { get; set; }
        public virtual Mjesto mjesto { get; set; }
    }


}
