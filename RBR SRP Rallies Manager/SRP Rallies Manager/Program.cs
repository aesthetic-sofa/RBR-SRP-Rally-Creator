using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRP_Rallies_Manager
{
    static class Program
    {
        /// <summary>
        /// Application entry point.
        /// </summary>
       


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            // TEST START
            SRP srp = new SRP();
            int stagenumber = srp.CountStages("France.srp");
            List<stage> stages = new List<stage>();

            stages = srp.ReadSRP(stages, "France.srp");
            stages = srp.NewRallyPartialToFull(stages, stagenumber);
            srp.WriteSRP(stages, stagenumber, "TestFrance.srp");
            // TEST END

        }
    }
}
