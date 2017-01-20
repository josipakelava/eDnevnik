namespace Api.Models
{
    using Newtonsoft.Json;
    using System;

    public class Ocjena
    {
        public virtual int id { get; set; }
        public virtual DateTime datum { get; set; }
        public virtual int ocjena { get; set; }
        public virtual Kategorija kategorija { get; set; }
        public virtual Predmet predmet { get; set; }
        public virtual Ucenik ucenik { get; set; }
    }

}
