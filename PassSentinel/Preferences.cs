using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassSentinel
{
    public static class Preferences
    {
        public static int RandomPasswordLength { get; set; }
        public static bool GenerateSymbols { get; set; }
        public static bool SearchUsername { get; set; }
        public static bool SearchNotes { get; set; }
        public static bool SearchURL { get; set; }
        public static int InactivityTimer { get; set; } // Minutes
        

    } // end class
}
