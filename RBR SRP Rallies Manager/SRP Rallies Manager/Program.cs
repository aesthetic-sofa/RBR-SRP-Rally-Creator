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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            // TEST START
            SRP srp = new SRP();
            int stagenumber = srp.CountStages("TestFullSeason.srp");
            List<stage> stages = new List<stage>();

            stages = srp.ReadSRP(stages, "TestFullSeason.srp");
            stages = srp.RallyPartialToFull(stages, stagenumber);
            srp.WriteSRP(stages, stagenumber, "SelfTestFullSeason.srp");
            stages.Clear();

            List<stage> stages2 = new List<stage>();
            int stagenumber2 = srp.CountStages("Australia.srp");

            stages2 = srp.ReadSRP(stages, "Australia.srp");
            stages2 = srp.RallyPartialToFull(stages2, stagenumber2);
            srp.WriteSRP(stages2, stagenumber2, "TestAustralia.srp");
            stages2.Clear();

            List<stage> stages3 = new List<stage>();
            int stagenumber3 = srp.CountStages("Great Britain.srp");

            stages3 = srp.ReadSRP(stages, "Great Britain.srp");
            stages3 = srp.RallyPartialToFull(stages3, stagenumber3);
            srp.WriteSRP(stages3, stagenumber3, "TestGreatBritain.srp");
            stages3.Clear();

            CSV csv = new CSV();
            List<ValidCombo> tracklist = new List<ValidCombo>();
            tracklist=csv.ReadCSV();
            csv.writeCSV(tracklist, "test.csv");
            // TEST END

        }
    }
}
