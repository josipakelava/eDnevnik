namespace Api.Models
{
    using System;
    
    public class imaOcjenu
    {
        public virtual int id { get; set; }
        public virtual DateTime datum { get; set; }
        public virtual int ocjena { get; set; }
        public virtual Kategorija kategorija { get; set; }
        public virtual Predmet predmet { get; set; }
        public virtual Ucenik ucenik{ get; set; }
    }
}
