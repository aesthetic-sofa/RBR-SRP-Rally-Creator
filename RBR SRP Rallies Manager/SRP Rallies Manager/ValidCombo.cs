using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_Rallies_Manager
{
    class ValidCombo // A single line of the CSV TrackListing file.
    {
        // Variables.
        private int stageNumber;
        private string stageName, tintSet, conditions, sky, timeOfDay, surface, track;

        public int StageNumber { get => stageNumber; set => stageNumber = value; }
        public string StageName { get => stageName; set => stageName = value; }
        public string TintSet { get => tintSet; set => tintSet = value; }
        public string Conditions { get => conditions; set => conditions = value; }
        public string Sky { get => sky; set => sky = value; }
        public string TimeOfDay { get => timeOfDay; set => timeOfDay = value; }
        public string Surface { get => surface; set => surface = value; }
        public string Track { get => track; set => track = value; }

    }
}
