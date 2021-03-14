using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_Rallies_Manager
{
    class CSV
    {
        public List<ValidCombo> ReadCSV()
        {
            List<ValidCombo> trackList = new List<ValidCombo>(); // We create a list of valid combinations.

            int i = 0;

            var lines = File.ReadLines("TrackListing.csv"); // We read the file.

            ValidCombo combo = new ValidCombo();

            trackList.Insert(i, combo);

            foreach (var line in lines) // For each line of the file, we parse the data and fill the combos.
            {

                string[] words = line.Split(';'); // We split each line in a string vector.

                if (words[1] == "invalid stage" || words[0] == "Stage Number")
                {
                    continue;
                }

                trackList[i].StageNumber = Int32.Parse(words[0]);
                trackList[i].StageName = words[1];
                trackList[i].TintSet = words[2];
                trackList[i].Conditions = words[3];
                trackList[i].Sky = words[4];
                trackList[i].TimeOfDay = words[5];
                trackList[i].Surface = words[6];
                trackList[i].Track = words[7];

                trackList.Add(new ValidCombo());
                i++;

            }

            return trackList;
        }

        public void WriteValidCombo(ValidCombo combo, string filepath) // Writes a full CSV of the valid combos. Useful for debugging.
        {
            using (StreamWriter writer = File.AppendText(filepath))
            {

                // We write the combo fields to the specified file.
                //writer.WriteLine(combo.StageNumber.ToString(),';',combo.StageName,';',combo.TintSet,';',
                //    combo.Conditions,';',combo.Sky,';',combo.TimeOfDay,';',combo.Surface,';',combo.Track);
                writer.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7}", combo.StageNumber.ToString(), combo.StageName, combo.TintSet, combo.Conditions, combo.Sky, combo.TimeOfDay, combo.Surface, combo.Track);

                // We close the stream.
                writer.Close();
            }
        }

        public void writeCSV(List<ValidCombo> tracklist, string filepath) // Writes a full CSV of the valid combos. Useful for debugging.
        {
            using (StreamWriter fileCreator = File.CreateText(filepath))
            {
                fileCreator.WriteLine("Stage Number;Stage Name;Tint Set;Conditions;Sky;Time Of Day;Surface;Track");
                fileCreator.Close();
            }

            for (int i = 0; i < tracklist.Count; i++)
                WriteValidCombo(tracklist[i], filepath);
        }
        

    }
}
