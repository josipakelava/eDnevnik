namespace Domena
{
    using System;

    public class Biljeska
    {
        public virtual int id { get; set; }
        public virtual DateTime datum { get; set; }
        public virtual string biljeska { get; set; }
        public virtual Predmet predmet { get; set; }
        public virtual Ucenik ucenik { get; set; }
    }

}
