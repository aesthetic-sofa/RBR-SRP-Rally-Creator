using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_Rallies_Manager
{
    partial class SRP
    {

        public stage DefaultStage(stage stage) // Sets every field of a stage to "".
        {
            stage.Servicetime = "";
            stage.Mechanics = "";
            stage.Skill = "";
            stage.Weather = "";
            stage.Tyres = "";
            stage.Conditions = "";
            stage.Sky = "";
            stage.TimeOfDay = "";
            stage.Surface = "";
            stage.Track = "";
            stage.Setup = "";
            stage.Hotlap = "";
            stage.Stagenn = "";
            stage.Stagelabel = "";

            return stage;
        }

        public stage TrimStage(stage stage) // Deletes unwanted white spaces from every field of a stage.
        {
            if (stage.Servicetime != null) stage.Servicetime=stage.Servicetime.Trim();
            if (stage.Mechanics != null) stage.Mechanics=stage.Mechanics.Trim();
            if (stage.Skill != null) stage.Skill=stage.Skill.Trim();
            if (stage.Weather != null) stage.Weather=stage.Weather.Trim();
            if (stage.Tyres != null) stage.Tyres=stage.Tyres.Trim();
            if (stage.Conditions != null) stage.Conditions=stage.Conditions.Trim();
            if (stage.Sky != null) stage.Sky=stage.Sky.Trim();
            if (stage.TimeOfDay != null) stage.TimeOfDay=stage.TimeOfDay.Trim();
            if (stage.Surface != null) stage.Surface=stage.Surface.Trim();
            if (stage.Track != null) stage.Track=stage.Track.Trim();
            if (stage.Setup != null) stage.Setup=stage.Setup.Trim();
            if (stage.Hotlap != null) stage.Hotlap=stage.Hotlap.Trim();
            if (stage.Stagenn != null) stage.Stagenn=stage.Stagenn.Trim();
            if (stage.Stagelabel != null) stage.Stagelabel=stage.Stagelabel.Trim();

            return stage;
        }

        public stage CopyStage(stage target, stage source) // Copies a stage to another. !! DEPRECATED !!
        {
            target.Servicetime = source.Servicetime;
            target.Mechanics = source.Mechanics;
            target.Skill = source.Skill;
            target.Weather = source.Weather;
            target.Tyres = source.Tyres;
            target.Conditions = source.Conditions;
            target.Sky = source.Sky;
            target.TimeOfDay = source.TimeOfDay;
            target.Surface = source.Surface;
            target.Track = source.Track;
            target.Setup = source.Setup;
            target.Hotlap = source.Hotlap;
            target.Stagenn = source.Stagenn;
            target.Stagelabel = source.Stagelabel;

            return target;
        }

        public bool isPartialValid(string partial, string full)
        {
            bool valid = false;

            if (partial.Contains(' '))
            {
                string[] partialSplit = partial.Split(' ');
                string[] fullSplit = full.Split(' ');

                //List<string> partialSplit = partialSplitArray.ToList();
                //List<string> fullSplit = fullSplitArray.ToList();

                bool checkword0 = false;
                bool checkword1 = false;
                bool checkword2 = false;
                bool checkword3 = false;

                for (int i = 0; i < fullSplit[0].Length; i++)
                {
                    string substringWord0 = fullSplit[0].Substring(0, i);
                    bool checkA = String.Equals(partialSplit[0], substringWord0, StringComparison.OrdinalIgnoreCase);
                    if (checkA == true) checkword0 = true;
                }
                int count0 = fullSplit.Count();
                if ( count0 == 2)
                {
                    for (int j = 0; j < fullSplit[1].Length; j++)
                    {
                        string substringWord1 = fullSplit[1].Substring(0, j);
                        bool checkB = String.Equals(partialSplit[1], substringWord1, StringComparison.OrdinalIgnoreCase);
                        if (checkB == true) checkword1 = true;
                    }
                }


                if (checkword0 == true && checkword1 == true) valid = true;
                else
                {
                    int count1 = fullSplit.Count();
                    if (count1 == 2)
                    {
                        for (int k = 0; k < fullSplit[1].Length; k++)
                        {
                            string substringWord2 = fullSplit[1].Substring(0, k);
                            bool checkC = String.Equals(partialSplit[0], substringWord2, StringComparison.OrdinalIgnoreCase);
                            if (checkC == true) checkword2 = true;
                        }
                    }


                    for (int l = 0; l < fullSplit[0].Length; l++)
                    {
                        string substringWord3 = fullSplit[0].Substring(0, l);
                        bool checkD = String.Equals(partialSplit[1], substringWord3, StringComparison.OrdinalIgnoreCase);
                        if (checkD == true) checkword3 = true;
                    }
                }
                if (checkword2 == true && checkword3 == true) valid = true;

            }

            else
            {
                int fullLength = full.Length;
                bool check = false;
                for (int i = 0; i < fullLength; i++)
                {
                    string substring = full.Substring(0, i);
                    check = String.Equals(partial, substring, StringComparison.OrdinalIgnoreCase);
                    if (check == true) valid = true;

                }
            }

            return valid;
        }

        public stage PartialToFull(stage stage)
        {
            // Weather translations.
            if (isPartialValid(stage.Weather, "dry") == true && stage.Weather != "") stage.Weather = "good";
            else if (isPartialValid(stage.Weather, "good") == true && stage.Weather != "") stage.Weather = "good";
            else if (isPartialValid(stage.Weather, "random") == true && stage.Weather != "") stage.Weather = "random";
            else if (isPartialValid(stage.Weather, "bad") == true && stage.Weather != "") stage.Weather = "bad";

            // Tyres translation.
            if (isPartialValid(stage.Tyres, "tarmac dry") == true && stage.Tyres != "") stage.Tyres = "tarmac dry";
            else if (isPartialValid(stage.Tyres, "tarmac intermediate") == true && stage.Tyres != "") stage.Tyres = "tarmac intermediate";
            else if (isPartialValid(stage.Tyres, "tarmac wet") == true && stage.Tyres != "") stage.Tyres = "tarmac wet";
            else if (isPartialValid(stage.Tyres, "gravel dry") == true && stage.Tyres != "") stage.Tyres = "gravel dry";
            else if (isPartialValid(stage.Tyres, "gravel intermediate") == true && stage.Tyres != "") stage.Tyres = "gravel intermediate";
            else if (isPartialValid(stage.Tyres, "gravel wet") == true && stage.Tyres != "") stage.Tyres = "gravel wet";
            else if (isPartialValid(stage.Tyres, "snow") == true && stage.Tyres != "") stage.Tyres = "snow";

            // Conditions translation.
            if (isPartialValid(stage.Conditions, "crisp") == true && stage.Conditions != "") stage.Conditions = "crisp";
            else if (isPartialValid(stage.Conditions, "hazy") == true && stage.Conditions != "") stage.Conditions = "hazy";
            else if (isPartialValid(stage.Conditions, "norain") == true && stage.Conditions != "") stage.Conditions = "norain";
            else if (isPartialValid(stage.Conditions, "lightrain") == true && stage.Conditions != "") stage.Conditions = "lightrain";
            else if (isPartialValid(stage.Conditions, "heavyrain") == true && stage.Conditions != "") stage.Conditions = "heavyrain";
            else if (isPartialValid(stage.Conditions, "nosnow") == true && stage.Conditions != "") stage.Conditions = "nosnow";
            else if (isPartialValid(stage.Conditions, "lightsnow") == true && stage.Conditions != "") stage.Conditions = "lightsnow";
            else if (isPartialValid(stage.Conditions, "heavysnow") == true && stage.Conditions != "") stage.Conditions = "heavysnow";
            else if (isPartialValid(stage.Conditions, "lightfog") == true && stage.Conditions != "") stage.Conditions = "lightfog";
            else if (isPartialValid(stage.Conditions, "heavyfog") == true && stage.Conditions != "") stage.Conditions = "heavyfog";

            // Sky translation.
            if (isPartialValid(stage.Sky, "clear") == true && stage.Sky != "") stage.Sky = "clear";
            else if (isPartialValid(stage.Sky, "partcloud") == true && stage.Sky != "") stage.Sky = "partcloud";
            else if (isPartialValid(stage.Sky, "lightcloud") == true && stage.Sky != "") stage.Sky = "lightcloud";
            else if (isPartialValid(stage.Sky, "heavycloud") == true && stage.Sky != "") stage.Sky = "heavycloud";

            // TimeOfDay translation.
            if (isPartialValid(stage.TimeOfDay, "morning") == true && stage.TimeOfDay != "") stage.TimeOfDay = "morning";
            else if (isPartialValid(stage.TimeOfDay, "noon") == true && stage.TimeOfDay != "") stage.TimeOfDay = "noon";
            else if (isPartialValid(stage.TimeOfDay, "evening") == true && stage.TimeOfDay != "") stage.TimeOfDay = "evening";

            // Surface translation.
            if (isPartialValid(stage.Surface, "dry") == true && stage.Surface != "") stage.Surface = "dry";
            else if (isPartialValid(stage.Surface, "damp") == true && stage.Surface != "") stage.Surface = "damp";
            else if (isPartialValid(stage.Surface, "wet") == true && stage.Surface != "") stage.Surface = "wet";

            // Track translation.
            if (isPartialValid(stage.Track, "new") == true && stage.Track != "") stage.Track = "new";
            else if (isPartialValid(stage.Track, "normal") == true && stage.Track != "") stage.Track = "normal";
            else if (isPartialValid(stage.Track, "worn") == true && stage.Track != "") stage.Track = "worn";

            // Skill translation.
            if (isPartialValid(stage.Skill, "inexperienced") == true && stage.Skill != "") stage.Skill = "inexperienced";
            else if (isPartialValid(stage.Skill, "proficient") == true && stage.Skill != "") stage.Skill = "proficient";
            else if (isPartialValid(stage.Skill, "competent") == true && stage.Skill != "") stage.Skill = "competent";
            else if (isPartialValid(stage.Skill, "skilled") == true && stage.Skill != "") stage.Skill = "skilled";
            else if (isPartialValid(stage.Skill, "expert") == true && stage.Skill != "") stage.Skill = "expert";

            return stage;
        }

        public stage OldPartialToFull(stage stage)
        {
            // Weather translations.
            if (String.Equals(stage.Weather, "d", StringComparison.OrdinalIgnoreCase) == true) stage.Weather = "good";
            else if (String.Equals(stage.Weather, "g", StringComparison.OrdinalIgnoreCase) == true) stage.Weather = "good";
            else if (String.Equals(stage.Weather, "r", StringComparison.OrdinalIgnoreCase) == true) stage.Weather = "random";
            else if (String.Equals(stage.Weather, "b", StringComparison.OrdinalIgnoreCase) == true) stage.Weather = "bad";

            // Tyres translation.
            if (String.Equals(stage.Tyres, "t d", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "tarmac dry";
            else if (String.Equals(stage.Tyres, "d t", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "tarmac dry";
            else if (String.Equals(stage.Tyres, "t i", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "tarmac intermediate";
            else if (String.Equals(stage.Tyres, "i t", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "tarmac intermediate";
            else if (String.Equals(stage.Tyres, "t w", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "tarmac wet";
            else if (String.Equals(stage.Tyres, "w t", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "tarmac wet";
            else if (String.Equals(stage.Tyres, "g d", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "gravel dry";
            else if (String.Equals(stage.Tyres, "d g", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "gravel dry";
            else if (String.Equals(stage.Tyres, "g i", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "gravel intermediate";
            else if (String.Equals(stage.Tyres, "i g", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "gravel intermediate";
            else if (String.Equals(stage.Tyres, "g w", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "gravel wet";
            else if (String.Equals(stage.Tyres, "w g", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "gravel wet";
            else if (String.Equals(stage.Tyres, "s", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "snow";

            // Conditions translation.
            if (String.Equals(stage.Conditions, "c", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "crisp";
            else if (String.Equals(stage.Conditions, "ha", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "hazy";
            else if (String.Equals(stage.Conditions, "nor", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "norain";
            else if (String.Equals(stage.Conditions, "lightr", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "lightrain";
            else if (String.Equals(stage.Conditions, "heavyr", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "heavyrain";
            else if (String.Equals(stage.Conditions, "nos", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "nosnow";
            else if (String.Equals(stage.Conditions, "lights", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "lightsnow";
            else if (String.Equals(stage.Conditions, "heavys", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "heavysnow";
            else if (String.Equals(stage.Conditions, "lightf", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "lightfog";
            else if (String.Equals(stage.Conditions, "heavyf", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "heavyfog";

            // Sky translation.
            if (String.Equals(stage.Sky, "c", StringComparison.OrdinalIgnoreCase) == true) stage.Sky = "clear";
            else if (String.Equals(stage.Sky, "p", StringComparison.OrdinalIgnoreCase) == true) stage.Sky = "partcloud";
            else if (String.Equals(stage.Sky, "l", StringComparison.OrdinalIgnoreCase) == true) stage.Sky = "lightcloud";
            else if (String.Equals(stage.Sky, "h", StringComparison.OrdinalIgnoreCase) == true) stage.Sky = "heavycloud";

            // TimeOfDay translation.
            if (String.Equals(stage.TimeOfDay, "m", StringComparison.OrdinalIgnoreCase) == true) stage.TimeOfDay = "morning";
            else if (String.Equals(stage.TimeOfDay, "n", StringComparison.OrdinalIgnoreCase) == true) stage.TimeOfDay = "noon";
            else if (String.Equals(stage.TimeOfDay, "e", StringComparison.OrdinalIgnoreCase) == true) stage.TimeOfDay = "evening";

            // Surface translation.
            if (String.Equals(stage.Surface, "dr", StringComparison.OrdinalIgnoreCase) == true) stage.Surface = "dry";
            else if (String.Equals(stage.Surface, "da", StringComparison.OrdinalIgnoreCase) == true) stage.Surface = "damp";
            else if (String.Equals(stage.Surface, "w", StringComparison.OrdinalIgnoreCase) == true) stage.Surface = "wet";

            // Track translation.
            if (String.Equals(stage.Track, "ne", StringComparison.OrdinalIgnoreCase) == true) stage.Track = "new";
            else if (String.Equals(stage.Track, "no", StringComparison.OrdinalIgnoreCase) == true) stage.Track = "normal";
            else if (String.Equals(stage.Track, "w", StringComparison.OrdinalIgnoreCase) == true) stage.Track = "worn";

            // Skill translation.
            if (String.Equals(stage.Skill, "i", StringComparison.OrdinalIgnoreCase) == true) stage.Skill = "inexperienced";
            else if (String.Equals(stage.Skill, "p", StringComparison.OrdinalIgnoreCase) == true) stage.Skill = "proficient";
            else if (String.Equals(stage.Skill, "c", StringComparison.OrdinalIgnoreCase) == true) stage.Skill = "competent";
            else if (String.Equals(stage.Skill, "s", StringComparison.OrdinalIgnoreCase) == true) stage.Skill = "skilled";
            else if (String.Equals(stage.Skill, "e", StringComparison.OrdinalIgnoreCase) == true) stage.Skill = "expert";

            return stage;
        }

        public stage NumberToFull(stage stage)
        {
            // Weather translations.
            if (String.Equals(stage.Weather, "0", StringComparison.OrdinalIgnoreCase) == true) stage.Weather = "good";
            else if (String.Equals(stage.Weather, "1", StringComparison.OrdinalIgnoreCase) == true) stage.Weather = "random";
            else if (String.Equals(stage.Weather, "2", StringComparison.OrdinalIgnoreCase) == true) stage.Weather = "bad";

            // Tyres translation.
            if (String.Equals(stage.Tyres, "0", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "tarmac dry";
            else if (String.Equals(stage.Tyres, "1", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "tarmac intermediate";
            else if (String.Equals(stage.Tyres, "2", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "tarmac wet";
            else if (String.Equals(stage.Tyres, "3", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "gravel dry";
            else if (String.Equals(stage.Tyres, "4", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "gravel intermediate";
            else if (String.Equals(stage.Tyres, "5", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "gravel wet";
            else if (String.Equals(stage.Tyres, "6", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "snow";

            // Conditions translation.
            if (String.Equals(stage.Conditions, "0", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "crisp";
            else if (String.Equals(stage.Conditions, "1", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "hazy";
            else if (String.Equals(stage.Conditions, "2", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "norain";
            else if (String.Equals(stage.Conditions, "3", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "lightrain";
            else if (String.Equals(stage.Conditions, "4", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "heavyrain";
            else if (String.Equals(stage.Conditions, "5", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "nosnow";
            else if (String.Equals(stage.Conditions, "6", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "lightsnow";
            else if (String.Equals(stage.Conditions, "7", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "heavysnow";
            else if (String.Equals(stage.Conditions, "8", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "lightfog";
            else if (String.Equals(stage.Conditions, "9", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "heavyfog";

            // Sky translation.
            if (String.Equals(stage.Sky, "0", StringComparison.OrdinalIgnoreCase) == true) stage.Sky = "clear";
            else if (String.Equals(stage.Sky, "1", StringComparison.OrdinalIgnoreCase) == true) stage.Sky = "partcloud";
            else if (String.Equals(stage.Sky, "2", StringComparison.OrdinalIgnoreCase) == true) stage.Sky = "lightcloud";
            else if (String.Equals(stage.Sky, "3", StringComparison.OrdinalIgnoreCase) == true) stage.Sky = "heavycloud";

            // TimeOfDay translation.
            if (String.Equals(stage.TimeOfDay, "0", StringComparison.OrdinalIgnoreCase) == true) stage.TimeOfDay = "morning";
            else if (String.Equals(stage.TimeOfDay, "1", StringComparison.OrdinalIgnoreCase) == true) stage.TimeOfDay = "noon";
            else if (String.Equals(stage.TimeOfDay, "2", StringComparison.OrdinalIgnoreCase) == true) stage.TimeOfDay = "evening";

            // Surface translation.
            if (String.Equals(stage.Surface, "0", StringComparison.OrdinalIgnoreCase) == true) stage.Surface = "dry";
            else if (String.Equals(stage.Surface, "1", StringComparison.OrdinalIgnoreCase) == true) stage.Surface = "damp";
            else if (String.Equals(stage.Surface, "2", StringComparison.OrdinalIgnoreCase) == true) stage.Surface = "wet";

            // Track translation.
            if (String.Equals(stage.Track, "0", StringComparison.OrdinalIgnoreCase) == true) stage.Track = "new";
            else if (String.Equals(stage.Track, "1", StringComparison.OrdinalIgnoreCase) == true) stage.Track = "normal";
            else if (String.Equals(stage.Track, "2", StringComparison.OrdinalIgnoreCase) == true) stage.Track = "worn";

            // Skill translation.
            if (String.Equals(stage.Skill, "1", StringComparison.OrdinalIgnoreCase) == true) stage.Skill = "inexperienced";
            else if (String.Equals(stage.Skill, "2", StringComparison.OrdinalIgnoreCase) == true) stage.Skill = "proficient";
            else if (String.Equals(stage.Skill, "3", StringComparison.OrdinalIgnoreCase) == true) stage.Skill = "competent";
            else if (String.Equals(stage.Skill, "4", StringComparison.OrdinalIgnoreCase) == true) stage.Skill = "skilled";
            else if (String.Equals(stage.Skill, "5", StringComparison.OrdinalIgnoreCase) == true) stage.Skill = "expert";

            return stage;
        }

        public void NormalizeStageAttributes(stage stage)
        {
            if (String.Equals(stage.Weather, "Good", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Weather, "Random", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Weather, "Bad", StringComparison.OrdinalIgnoreCase) == false)
            {
                stage.Weather = "";
            }

            if (String.Equals(stage.Tyres, "Tarmac Dry", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Tyres, "Tarmac Intermediate", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Tyres, "Tarmac Wet", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Tyres, "Gravel Dry", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Tyres, "Gravel Intermediate", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Tyres, "Gravel Wet", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Tyres, "Snow", StringComparison.OrdinalIgnoreCase) == false)
            {
                stage.Tyres = "";
            }

            if (String.Equals(stage.Conditions, "crisp", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Conditions, "hazy", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Conditions, "norain", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Conditions, "lightrain", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Conditions, "heavyrain", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Conditions, "nosnow", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Conditions, "lightsnow", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Conditions, "heavysnow", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Conditions, "lightfog", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Conditions, "heavyfog", StringComparison.OrdinalIgnoreCase) == false)
            {
                stage.Conditions = "";
            }

            if (String.Equals(stage.Sky, "clear", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Sky, "partcloud", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Sky, "lightcloud", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Sky, "heavycloud", StringComparison.OrdinalIgnoreCase) == false)
            {
                stage.Sky = "";
            }

            if (String.Equals(stage.TimeOfDay, "morning", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.TimeOfDay, "noon", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.TimeOfDay, "evening", StringComparison.OrdinalIgnoreCase) == false)
            {
                stage.TimeOfDay = "";
            }

            if (String.Equals(stage.Surface, "dry", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Surface, "damp", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Surface, "wet", StringComparison.OrdinalIgnoreCase) == false)
            {
                stage.Surface = "";
            }

            if (String.Equals(stage.Track, "new", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Track, "normal", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Track, "worn", StringComparison.OrdinalIgnoreCase) == false)
            {
                stage.Track = "";
            }

            if (int.TryParse(stage.Setup, out _) == false || int.Parse(stage.Setup)<-3)
            {
                stage.Setup = "";
            }

            if (int.TryParse(stage.Hotlap, out _) == false || (int.Parse(stage.Hotlap) != 0 && int.Parse(stage.Hotlap) != 1))
            {
                stage.Hotlap = "";
            }

            if (int.TryParse(stage.Servicetime, out _) == false || int.Parse(stage.Servicetime) < 0)
            {
                stage.Servicetime = "";
            }

            if (int.TryParse(stage.Mechanics, out _) == false || (int.Parse(stage.Mechanics) < 1 || int.Parse(stage.Mechanics) > 6))
            {
                stage.Mechanics = "";
            }

            if (String.Equals(stage.Skill, "inexperienced", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Skill, "proficient", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Skill, "competent", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Skill, "skilled", StringComparison.OrdinalIgnoreCase) == false &&
                String.Equals(stage.Skill, "expert", StringComparison.OrdinalIgnoreCase) == false)
            {
                stage.Skill = "";
            }

            if (int.TryParse(stage.Stagenn, out _) == false)
            {
                stage.Stagenn = "10";
            }
        }

        public string getFilePath(string filename) // Retrieves the path of the SRP given the filename.
        {
            string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string folderpath = dir + @"\plugins\TrainingDay\";
            string filepath = folderpath + filename;
            return filepath;
        }

        public int CountStages(string filepath) // Counts the number of stages in a given file.
        {
            var lines = File.ReadLines(filepath); // We read the file.
            short SSnumber = 0;
            foreach (var line in lines) // For each line of the file, we parse the data and fill the structs.
            {
                // Parsing begins.
                string[] words = line.Split('#'); // We split each line before and after '#'. What come after '#' won't be used anymore.
                string[] netWords = words[0].Split(' '); // We split the useful part of the line (before '#') into each word, using ' ' as separator.
                int netWordsCount = netWords.Length; // We keep track of how many words are in each useful part of line, so that we know if merging
                                                     // words is needed at a later point. 2 words (key+value) don't need any merging, 3 need instead.

                // We check what kind of data is stored in the strings we read, via inspecting the "key word" at the start of each line.
                bool isStageLine = String.Equals(netWords[0], "stage", StringComparison.OrdinalIgnoreCase);

                // We default all of the struct fields to "", for style.
                //SRPstruct.DefaultStage(stages[SSnumber]);
                if (isStageLine == true)
                {
                    SSnumber++; // We move on to the next stage.
                }
            }
            return SSnumber;
        }

        public List<stage> ReadSRP(List<stage> stages, string filepath)
        {
            
            var lines = File.ReadLines(filepath); // We read the file.
            short SSnumber = 0;
            stage stage = new stage();
            stages.Insert(SSnumber, stage);
            stages[SSnumber] = DefaultStage(stages[SSnumber]); // We prepare the first stage so that it's defaulted to "".
            foreach (var line in lines) // For each line of the file, we parse the data and fill the structs.
            {
                // We create a stage to put in the list.

                // Parsing begins.
                string[] words = line.Split('#'); // We split each line before and after '#'. What come after '#' won't be used anymore.
                string[] netWords = words[0].Split(' '); // We split the useful part of the line (before '#') into each word, using ' ' as separator.
                int netWordsCount = netWords.Length; // We keep track of how many words are in each useful part of line, so that we know if merging
                                                     // words is needed at a later point. 2 words (key+value) don't need any merging, 3 need instead.

                // We check what kind of data is stored in the strings we read, via inspecting the "key word" at the start of each line.
                bool isServiceLine = String.Equals(netWords[0], "service", StringComparison.OrdinalIgnoreCase);
                bool isMechanicsLine = String.Equals(netWords[0], "mechanics", StringComparison.OrdinalIgnoreCase);
                bool isSkillLine = String.Equals(netWords[0], "skill", StringComparison.OrdinalIgnoreCase);
                bool isWeatherLine = String.Equals(netWords[0], "weather", StringComparison.OrdinalIgnoreCase);
                bool isTyresLine = String.Equals(netWords[0], "tyres", StringComparison.OrdinalIgnoreCase);
                bool isConditionsLine = String.Equals(netWords[0], "conditions", StringComparison.OrdinalIgnoreCase);
                bool isSkyLine = String.Equals(netWords[0], "sky", StringComparison.OrdinalIgnoreCase);
                bool isTimeOfDayLine = String.Equals(netWords[0], "timeOfDay", StringComparison.OrdinalIgnoreCase);
                bool isSurfaceLine = String.Equals(netWords[0], "surface", StringComparison.OrdinalIgnoreCase);
                bool isTrackLine = String.Equals(netWords[0], "track", StringComparison.OrdinalIgnoreCase);
                bool isSetupLine = String.Equals(netWords[0], "setup", StringComparison.OrdinalIgnoreCase);
                bool isHotlapLine = String.Equals(netWords[0], "hotlap", StringComparison.OrdinalIgnoreCase);
                bool isStageLine = String.Equals(netWords[0], "stage", StringComparison.OrdinalIgnoreCase);
                

                // We populate the stage structs. We also join every word after the "key word" at the start of each line when needed.
                if (isServiceLine == true) stages[SSnumber].Servicetime = netWords[1];
                else if (isMechanicsLine == true) stages[SSnumber].Mechanics = netWords[1];
                else if (isSkillLine == true) stages[SSnumber].Skill = netWords[1];
                else if (isWeatherLine == true) stages[SSnumber].Weather = netWords[1];
                else if (isTyresLine == true)
                {
                    if (netWordsCount == 2) stages[SSnumber].Tyres = netWords[1];
                    else if (netWordsCount >= 3) stages[SSnumber].Tyres = (netWords[1] + " " + netWords[2]);
                }
                else if (isConditionsLine == true) stages[SSnumber].Conditions = netWords[1];
                else if (isSkyLine == true) stages[SSnumber].Sky = netWords[1];
                else if (isTimeOfDayLine == true) stages[SSnumber].TimeOfDay = netWords[1];
                else if (isSurfaceLine == true) stages[SSnumber].Surface = netWords[1];
                else if (isTrackLine == true) stages[SSnumber].Track = netWords[1];
                else if (isSetupLine == true) stages[SSnumber].Setup = netWords[1];
                else if (isHotlapLine == true) stages[SSnumber].Hotlap = netWords[1];
                else if (isStageLine == true)
                {
                    if (netWordsCount == 2) stages[SSnumber].Stagenn = netWords[1];
                    else if (netWordsCount >= 3) // If there is a label, the whole label must be joined and stored in the Stagelabel field.
                    {
                        stages[SSnumber].Stagenn = netWords[1];

                        for (int i = 2; i <= (netWordsCount - 1); i++)
                        {
                            stages[SSnumber].Stagelabel += (netWords[i] + " ");
                        }

                    }
                    stages.Add(new stage());
                    stages[SSnumber] = TrimStage(stages[SSnumber]); // We remove useless blank spaces.
                    SSnumber++; // We move on to the next stage.
                    stages[SSnumber] = DefaultStage(stages[SSnumber]); // We prepare the next stage so that it's defaulted to "".
                }
            }

            return stages;

        }

        public void WriteStage(stage stage, string filepath, int SSnumber) // Writes a single stage to a specified file.
        {
            using (StreamWriter writer = File.AppendText(filepath))
            {
                // We compose the needed strings.
                string lineservice = "service " + stage.Servicetime;
                string linemechanics = "mechanics " + stage.Mechanics;
                string lineskill = "skill " + stage.Skill;
                string lineweather = "weather " + stage.Weather;
                string linetyres = "tyres " + stage.Tyres;
                string lineconditions = "conditions " + stage.Conditions;
                string linesky = "sky " + stage.Sky;
                string linetimeOfDay = "timeOfDay " + stage.TimeOfDay;
                string linesurface = "surface " + stage.Surface;
                string linetrack = "track " + stage.Track;
                string linesetup = "setup " + stage.Setup;
                string linehotlap = "hotlap " + stage.Hotlap;
                string linestage = "stage " + stage.Stagenn + " " + stage.Stagelabel;

                writer.WriteLine("##### SS" + SSnumber + " #####"); // We add a separator (for style).

                // We write the composed strings to the specified file.
                if (stage.Servicetime != "") writer.WriteLine(lineservice);
                if (stage.Mechanics != "") writer.WriteLine(linemechanics);
                if (stage.Skill != "") writer.WriteLine(lineskill);
                if (stage.Weather != "") writer.WriteLine(lineweather);
                if (stage.Tyres != "") writer.WriteLine(linetyres);
                if (stage.Conditions != "") writer.WriteLine(lineconditions);
                if (stage.Sky != "") writer.WriteLine(linesky);
                if (stage.TimeOfDay != "") writer.WriteLine(linetimeOfDay);
                if (stage.Surface != "") writer.WriteLine(linesurface);
                if (stage.Track != "") writer.WriteLine(linetrack);
                if (stage.Setup != "") writer.WriteLine(linesetup);
                if (stage.Hotlap != "") writer.WriteLine(linehotlap);
                if (stage.Stagenn != "") writer.WriteLine(linestage);

                writer.WriteLine(); // We add another separator (for style).

                // We close the stream.
                writer.Close();
            }
        }

        public List<stage> OldRallyPartialToFull(List<stage> stages, int totalstagenumber) // Translates a whole rally (SRP) from partial to full notation.
        {
            for (int i = 0; i < totalstagenumber; i++) OldPartialToFull(stages[i]);
            return stages;
        }

        public List<stage> RallyPartialToFull(List<stage> stages, int totalstagenumber) // Translates a whole rally (SRP) from partial to full notation.
        {
            for (int i = 0; i < totalstagenumber; i++) PartialToFull(stages[i]);
            return stages;
        }

        public void WriteSRP(List<stage> stages, int totalstagenumber, string filepath)
        {
            using (StreamWriter writer = File.CreateText(filepath))
            {
                string specs = "# Legend:@n#@n# All tags and keywords are case-insensitive.@n# All tags except 'stage' and 'service' are sticky, which means that once set@n# their values remain the same for the stages following.@n# Keywords may be specified only partially as long as they are unique.@n# For example, tyres may be specified as 'gr dr' for Gravel Dry or 'dr gr' or@n# 'd g'.@n# You may use the numbers but these are much more harder to remember.@n#@n#@n# Tag           Partial             Full                    Number@n# --------------------------------------------------------------------------@n# weather       g                   Good                    0@n#               r                   Random                  1@n#               b                   Bad                     2@n#@n#@n# tyres         t d                 Tarmac Dry              0@n#               d t                 Tarmac Dry              0@n#@n#               t i                 Tarmac Intermediate     1@n#               i t                 Tarmac Intermediate     1@n#@n#               t w                 Tarmac Wet              2@n#               w t                 Tarmac Wet              2@n#@n#               g d                 Gravel Dry              3@n#               d g                 Gravel Dry              3@n#@n#               g i                 Gravel Intermediate     4@n#               i g                 Gravel Intermediate     4@n#@n#               g w                 Gravel Wet              5@n#               w g                 Gravel Wet              5@n#@n#               s                   Snow                    6@n#@n#@n#@n# conditions    -1=Reset previously defined value, use default.@n#               c                   crisp                   0@n#               ha                  hazy                    1@n#               nor                 norain                  2@n#               lightr              lightrain               3@n#               heavyr              heavyrain               4@n#               nos                 nosnow                  5@n#               lights              lightsnow               6@n#               heavys              heavysnow               7@n#               lightf              lightfog                8@n#               heavyf              heavyfog                9@n#@n#@n# sky           -1=Reset previously defined value, use default.@n#               c                   clear                   0@n#               p                   partcloud               1@n#               l                   lightcloud              2@n#               h                   heavycloud              3@n#@n#@n# timeOfDay     -1=Reset previously defined value, use default.@n#               m                   morning                 0@n#               n                   noon                    1@n#               e                   evening                 2@n#@n#@n# surface       -1=Reset previously defined value, use default.@n#               dr                  dry                     0@n#               da                  damp                    1@n#               w                   wet                     2@n#@n#@n# track         -1=Reset previously defined value, use default.@n#               ne                  new                     0@n#               no                  normal                  1@n#               w                   worn                    2@n#@n#@n# setup        -3=Use last setup chosen by user (menu-choice)@n#              -2=Default Setup@n#              -1=Current Setup@n#               0=Use setup in slot 0@n#               1=Use setup in slot 1@n#               2=Use setup in slot 2@n#               n=Use setup in slot <n>@n#@n#@n# hotlap        0=No hotlap@n#               1=special hotlap 'rally' stage@n#               If set to '1', the rally definition is being treated as a@n#               hotlap. This means that only one stage is included in the@n#               stage list and can be run as a hotlap.@n#               All other stage definitions in the rally config file, if@n#               present, are ignored.@n#@n#@n# service nn    nn=service park time in minutes after the stage@n#               Service park settings are ignored for hotlap rallies.@n# @n#@n# mechanics n   n=number of mechanics in the service park in the range 1..6@n#@n#@n# skill         skill level of the mechanics in the service park@n#               i                   inexperienced           1@n#               p                   proficient              2@n#               c                   competent               3@n#               s                   skilled                 4@n#               e                   expert                  5@n#               @n#@n#@n# stage nn label@n#         nn=Number of the stage.@n#         label=Optional label used as stage name for identification purposes.@n#         Everything after the stage number up to the end-of-line or a comment@n#         character (#) is treated as the label.@n#         The comparison used in computing the best time diffs based on this@n#         label is case-insensitive.@n#         Anyway the label is displayed as specified.@n#         If no label is specified (the default) the built-in stage name is@n#         being used as the label.@n#@n@n";
                specs = specs.Replace("@n", "\n");
                writer.Write(specs);

                for (int i = 0; i < totalstagenumber; i++)
                {
                    writer.WriteLine("##### SS" + (i+1) + " #####"); // We add a separator (for style).

                    // We write the composed strings to the specified file.
                    if (stages[i].Servicetime != "") writer.WriteLine("service " + stages[i].Servicetime);
                    if (stages[i].Mechanics != "") writer.WriteLine("mechanics " + stages[i].Mechanics);
                    if (stages[i].Skill != "") writer.WriteLine("skill " + stages[i].Skill);
                    if (stages[i].Weather != "") writer.WriteLine("weather " + stages[i].Weather);
                    if (stages[i].Tyres != "") writer.WriteLine("tyres " + stages[i].Tyres);
                    if (stages[i].Conditions != "") writer.WriteLine("conditions " + stages[i].Conditions);
                    if (stages[i].Sky != "") writer.WriteLine("sky " + stages[i].Sky);
                    if (stages[i].TimeOfDay != "") writer.WriteLine("timeOfDay " + stages[i].TimeOfDay);
                    if (stages[i].Surface != "") writer.WriteLine("surface " + stages[i].Surface);
                    if (stages[i].Track != "") writer.WriteLine("track " + stages[i].Track);
                    if (stages[i].Setup != "") writer.WriteLine("setup " + stages[i].Setup);
                    if (stages[i].Hotlap != "") writer.WriteLine("hotlap " + stages[i].Hotlap);
                    if (stages[i].Stagenn != "") writer.WriteLine("stage " + stages[i].Stagenn + " " + stages[i].Stagelabel);

                    writer.WriteLine(); // We add another separator (for style).

                }

                writer.Close();

            }
        }

    }
}
