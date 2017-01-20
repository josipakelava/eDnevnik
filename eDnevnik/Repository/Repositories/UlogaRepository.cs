using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UlogaRepository : IUlogaRepository
    {
        public IList<string> GetAll()
        {
            IList<string> uloge = new List<string>();
            uloge.Add("Ucenik");
            //uloge.Add("Razrednik");
            uloge.Add("Profesor");
            uloge.Add("Administrator");

            return uloge;
        }
    }
}
