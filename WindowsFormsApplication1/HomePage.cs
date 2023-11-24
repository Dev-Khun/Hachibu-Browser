using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class HomePage
    {
        static string Homepage = "";

        public static string Home
        {
            get { return Homepage; }

            set { Homepage = value; }
        }
    }
}
