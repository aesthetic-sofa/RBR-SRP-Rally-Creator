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
            int stagenumber = srp.CountStages("FullSeason.srp");
            List<stage> stages = new List<stage>();

            stages = srp.ReadSRP(stages, "FullSeason.srp");
            stages = srp.NewRallyPartialToFull(stages, stagenumber);
            srp.WriteSRP(stages, stagenumber, "TestFullSeason.srp");

            CSV csv = new CSV();
            List<ValidCombo> tracklist = new List<ValidCombo>();
            tracklist=csv.ReadCSV();
            csv.writeCSV(tracklist, "test.csv");
            // TEST END

        }
    }
}
