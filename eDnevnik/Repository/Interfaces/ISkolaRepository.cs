using Domena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ISkolaRepository
    {
        IList<Skola> GetAllSchool();
    }
}
