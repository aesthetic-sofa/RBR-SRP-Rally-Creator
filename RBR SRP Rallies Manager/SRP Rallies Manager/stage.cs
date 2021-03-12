using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_Rallies_Manager
{
    class stage
    {
        // Stage.
        private string weather, tyres, conditions, sky, timeOfDay, surface, track, stagelabel, setup, hotlap, stagenn;

        public string Stagenn { get => stagenn; set => stagenn = value; }
        public string Setup { get => setup; set => setup = value; }
        public string Hotlap { get => hotlap; set => hotlap = value; }
        public string Weather { get => weather; set => weather = value; }
        public string Tyres { get => tyres; set => tyres = value; }
        public string Conditions { get => conditions; set => conditions = value; }
        public string Sky { get => sky; set => sky = value; }
        public string TimeOfDay { get => timeOfDay; set => timeOfDay = value; }
        public string Surface { get => surface; set => surface = value; }
        public string Track { get => track; set => track = value; }
        public string Stagelabel { get => stagelabel; set => stagelabel = value; }

        // Service.
        private string skill, servicetime, mechanics;

        public string Servicetime { get => servicetime; set => servicetime = value; }
        public string Mechanics { get => mechanics; set => mechanics = value; }
        public string Skill { get => skill; set => skill = value; }
    }
}
