using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop
{
    public static class Helpers
    {
        public static string MjesecURimski(int number)
        {
            if (number < 1) return String.Empty;
            if (number > 12) return String.Empty;

            if (number >= 10) return "X" + MjesecURimski(number - 10);
            if (number >= 9) return "IX" + MjesecURimski(number - 9);
            if (number >= 5) return "V" + MjesecURimski(number - 5);
            if (number >= 4) return "IV" + MjesecURimski(number - 4);
            if (number >= 1) return "I" + MjesecURimski(number - 1);

            return String.Empty;
        }

        public static string Datum(DateTime d)
        {
            return d.Day.ToString() + "." + d.Month.ToString() + "." + d.Year.ToString() + ".";
        }
    }
}
