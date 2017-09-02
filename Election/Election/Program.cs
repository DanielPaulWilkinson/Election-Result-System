using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Election
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            // Create IO Handler (in this case a local file reader
            var IOhandler = new XMLFileReader();


            // To view this application as a console app 
            //please uncomment the next to lines and comment the last line.
            //thank you

            //var UI = new ConsoleBasedUI(IOhandler);
            //UI.Run();

            Application.Run(new FormBasedUI(IOhandler));
        }
    }
}
