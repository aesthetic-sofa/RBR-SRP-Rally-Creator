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
            int stagenumber = srp.CountStages(srp.getFilePath("France.srp"));
            List<stage> stages = new List<stage>();

            stages = srp.ReadSRP(stages, srp.getFilePath("France.srp"));
            stages = srp.RallyPartialToFull(stages, stagenumber);
            srp.WriteSRP(stages, stagenumber, srp.getFilePath("TestFrance.srp"));
            stages.Clear();

            int stagenumber2 = srp.CountStages(srp.getFilePath("Australia.srp"));

            stages = srp.ReadSRP(stages, srp.getFilePath("Australia.srp"));
            stages = srp.RallyPartialToFull(stages, stagenumber2);
            srp.WriteSRP(stages, stagenumber2, srp.getFilePath("TestAustralia.srp"));
            stages.Clear();


            int stagenumber3 = srp.CountStages(srp.getFilePath("Great Britain.srp"));

            stages = srp.ReadSRP(stages, srp.getFilePath("Great Britain.srp"));
            stages = srp.RallyPartialToFull(stages, stagenumber3);
            srp.WriteSRP(stages, stagenumber3, srp.getFilePath("TestGreatBritain.srp"));
            stages.Clear();

            CSV csv = new CSV();
            List<ValidCombo> tracklist = new List<ValidCombo>();
            tracklist=csv.ReadCSV();
            csv.writeCSV(tracklist, "test.csv");
            // TEST END

        }
    }
}
