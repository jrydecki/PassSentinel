using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassSentinel
{
    public static class Globals
    {
        public static Int64 UserID { get; set; }
        public static string Username { get; set; }

        public static PassSentinelDatabase DB { get; set; }
        
        public static void ErrorOut(string message, int code = 1)
        {
            ErrorForm errorForm = new ErrorForm();
            errorForm.SetText(message);
            errorForm.ShowDialog();

            Environment.Exit(code);
        } // end ErrorOut

    } // end class
}
