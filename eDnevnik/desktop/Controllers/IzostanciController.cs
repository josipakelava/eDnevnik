using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Controllers
{
    public class IzostanciController
    {
        private IzostanakRepository _repo = null;

        public IzostanciController()
        {
            _repo = new IzostanakRepository();
        }

        public void Izostanak(int id, bool opravdanost, string biljeska)
        {
            _repo.UpdateIzostanak(id, opravdanost, biljeska);
        }
    }
}
