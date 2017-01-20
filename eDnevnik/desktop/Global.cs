using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop
{
    static class Global
    {
        public static string _host = "http://localhost:3983/";

        public static string HOST
        {
            get { return _host; }
        }
    }
}
