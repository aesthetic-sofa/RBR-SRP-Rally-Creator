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
            if(stage.Servicetime != null) stage.Servicetime=stage.Servicetime.Trim();
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

        public stage NewPartialToFull(stage stage)
        {
            // Weather translations.
            if (isPartialValid(stage.Weather, "dry") == true && stage.Weather != "") stage.Weather = "dry";
            if (isPartialValid(stage.Weather, "random") == true && stage.Weather != "") stage.Weather = "random";
            if (isPartialValid(stage.Weather, "bad") == true && stage.Weather != "") stage.Weather = "bad";

            // Tyres translation.
            if (isPartialValid(stage.Tyres, "tarmac dry") == true && stage.Tyres != "") stage.Tyres = "tarmac dry";
            if (isPartialValid(stage.Tyres, "tarmac intermediate") == true && stage.Tyres != "") stage.Tyres = "tarmac intermediate";
            if (isPartialValid(stage.Tyres, "tarmac wet") == true && stage.Tyres != "") stage.Tyres = "tarmac wet";
            if (isPartialValid(stage.Tyres, "gravel dry") == true && stage.Tyres != "") stage.Tyres = "gravel dry";
            if (isPartialValid(stage.Tyres, "gravel intermediate") == true && stage.Tyres != "") stage.Tyres = "gravel intermediate";
            if (isPartialValid(stage.Tyres, "gravel wet") == true && stage.Tyres != "") stage.Tyres = "gravel wet";
            if (isPartialValid(stage.Tyres, "snow") == true && stage.Tyres != "") stage.Tyres = "snow";

            // Conditions translation.
            if (isPartialValid(stage.Conditions, "crisp") == true && stage.Conditions != "") stage.Conditions = "crisp";
            if (isPartialValid(stage.Conditions, "hazy") == true && stage.Conditions != "") stage.Conditions = "hazy";
            if (isPartialValid(stage.Conditions, "norain") == true && stage.Conditions != "") stage.Conditions = "norain";
            if (isPartialValid(stage.Conditions, "lightrain") == true && stage.Conditions != "") stage.Conditions = "lightrain";
            if (isPartialValid(stage.Conditions, "heavyrain") == true && stage.Conditions != "") stage.Conditions = "heavyrain";
            if (isPartialValid(stage.Conditions, "nosnow") == true && stage.Conditions != "") stage.Conditions = "nosnow";
            if (isPartialValid(stage.Conditions, "lightsnow") == true && stage.Conditions != "") stage.Conditions = "lightsnow";
            if (isPartialValid(stage.Conditions, "heavysnow") == true && stage.Conditions != "") stage.Conditions = "heavysnow";
            if (isPartialValid(stage.Conditions, "lightfog") == true && stage.Conditions != "") stage.Conditions = "lightfog";
            if (isPartialValid(stage.Conditions, "heavyfog") == true && stage.Conditions != "") stage.Conditions = "heavyfog";

            // Sky translation.
            if (isPartialValid(stage.Sky, "clear") == true && stage.Sky != "") stage.Sky = "clear";
            if (isPartialValid(stage.Sky, "partcloud") == true && stage.Sky != "") stage.Sky = "partcloud";
            if (isPartialValid(stage.Sky, "lightcloud") == true && stage.Sky != "") stage.Sky = "lightcloud";
            if (isPartialValid(stage.Sky, "heavycloud") == true && stage.Sky != "") stage.Sky = "heavycloud";

            // TimeOfDay translation.
            if (isPartialValid(stage.TimeOfDay, "morning") == true && stage.TimeOfDay != "") stage.TimeOfDay = "morning";
            if (isPartialValid(stage.TimeOfDay, "noon") == true && stage.TimeOfDay != "") stage.TimeOfDay = "noon";
            if (isPartialValid(stage.TimeOfDay, "evening") == true && stage.TimeOfDay != "") stage.TimeOfDay = "evening";

            // Surface translation.
            if (isPartialValid(stage.Surface, "dry") == true && stage.Surface != "") stage.Surface = "dry";
            if (isPartialValid(stage.Surface, "damp") == true && stage.Surface != "") stage.Surface = "damp";
            if (isPartialValid(stage.Surface, "wet") == true && stage.Surface != "") stage.Surface = "wet";

            // Track translation.
            if (isPartialValid(stage.Track, "new") == true && stage.Track != "") stage.Track = "new";
            if (isPartialValid(stage.Track, "normal") == true && stage.Track != "") stage.Track = "normal";
            if (isPartialValid(stage.Track, "worn") == true && stage.Track != "") stage.Track = "worn";

            // Skill translation.
            if (isPartialValid(stage.Skill, "inexperienced") == true && stage.Skill != "") stage.Skill = "inexperienced";
            if (isPartialValid(stage.Skill, "proficient") == true && stage.Skill != "") stage.Skill = "proficient";
            if (isPartialValid(stage.Skill, "competent") == true && stage.Skill != "") stage.Skill = "competent";
            if (isPartialValid(stage.Skill, "skilled") == true && stage.Skill != "") stage.Skill = "skilled";
            if (isPartialValid(stage.Skill, "expert") == true && stage.Skill != "") stage.Skill = "expert";

            return stage;
        }

        public stage PartialToFull(stage stage)
        {
            // Weather translations.
            if (String.Equals(stage.Weather, "d", StringComparison.OrdinalIgnoreCase) == true) stage.Weather = "dry";
            if (String.Equals(stage.Weather, "r", StringComparison.OrdinalIgnoreCase) == true) stage.Weather = "random";
            if (String.Equals(stage.Weather, "b", StringComparison.OrdinalIgnoreCase) == true) stage.Weather = "bad";

            // Tyres translation.
            if (String.Equals(stage.Tyres, "t d", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "tarmac dry";
            if (String.Equals(stage.Tyres, "d t", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "tarmac dry";
            if (String.Equals(stage.Tyres, "t i", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "tarmac intermediate";
            if (String.Equals(stage.Tyres, "i t", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "tarmac intermediate";
            if (String.Equals(stage.Tyres, "t w", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "tarmac wet";
            if (String.Equals(stage.Tyres, "w t", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "tarmac wet";
            if (String.Equals(stage.Tyres, "g d", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "gravel dry";
            if (String.Equals(stage.Tyres, "d g", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "gravel dry";
            if (String.Equals(stage.Tyres, "g i", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "gravel intermediate";
            if (String.Equals(stage.Tyres, "i g", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "gravel intermediate";
            if (String.Equals(stage.Tyres, "g w", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "gravel wet";
            if (String.Equals(stage.Tyres, "w g", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "gravel wet";
            if (String.Equals(stage.Tyres, "s", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "snow";

            // Conditions translation.
            if (String.Equals(stage.Conditions, "c", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "crisp";
            if (String.Equals(stage.Conditions, "ha", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "hazy";
            if (String.Equals(stage.Conditions, "nor", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "norain";
            if (String.Equals(stage.Conditions, "lightr", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "lightrain";
            if (String.Equals(stage.Conditions, "heavyr", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "heavyrain";
            if (String.Equals(stage.Conditions, "nos", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "nosnow";
            if (String.Equals(stage.Conditions, "lights", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "lightsnow";
            if (String.Equals(stage.Conditions, "heavys", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "heavysnow";
            if (String.Equals(stage.Conditions, "lightf", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "lightfog";
            if (String.Equals(stage.Conditions, "heavyf", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "heavyfog";

            // Sky translation.
            if (String.Equals(stage.Sky, "c", StringComparison.OrdinalIgnoreCase) == true) stage.Sky = "clear";
            if (String.Equals(stage.Sky, "p", StringComparison.OrdinalIgnoreCase) == true) stage.Sky = "partcloud";
            if (String.Equals(stage.Sky, "l", StringComparison.OrdinalIgnoreCase) == true) stage.Sky = "lightcloud";
            if (String.Equals(stage.Sky, "h", StringComparison.OrdinalIgnoreCase) == true) stage.Sky = "heavycloud";

            // TimeOfDay translation.
            if (String.Equals(stage.TimeOfDay, "m", StringComparison.OrdinalIgnoreCase) == true) stage.TimeOfDay = "morning";
            if (String.Equals(stage.TimeOfDay, "n", StringComparison.OrdinalIgnoreCase) == true) stage.TimeOfDay = "noon";
            if (String.Equals(stage.TimeOfDay, "e", StringComparison.OrdinalIgnoreCase) == true) stage.TimeOfDay = "evening";

            // Surface translation.
            if (String.Equals(stage.Surface, "dr", StringComparison.OrdinalIgnoreCase) == true) stage.Surface = "dry";
            if (String.Equals(stage.Surface, "da", StringComparison.OrdinalIgnoreCase) == true) stage.Surface = "damp";
            if (String.Equals(stage.Surface, "w", StringComparison.OrdinalIgnoreCase) == true) stage.Surface = "wet";

            // Track translation.
            if (String.Equals(stage.Track, "ne", StringComparison.OrdinalIgnoreCase) == true) stage.Track = "new";
            if (String.Equals(stage.Track, "no", StringComparison.OrdinalIgnoreCase) == true) stage.Track = "normal";
            if (String.Equals(stage.Track, "w", StringComparison.OrdinalIgnoreCase) == true) stage.Track = "worn";

            // Skill translation.
            if (String.Equals(stage.Skill, "i", StringComparison.OrdinalIgnoreCase) == true) stage.Skill = "inexperienced";
            if (String.Equals(stage.Skill, "p", StringComparison.OrdinalIgnoreCase) == true) stage.Skill = "proficient";
            if (String.Equals(stage.Skill, "c", StringComparison.OrdinalIgnoreCase) == true) stage.Skill = "competent";
            if (String.Equals(stage.Skill, "s", StringComparison.OrdinalIgnoreCase) == true) stage.Skill = "skilled";
            if (String.Equals(stage.Skill, "e", StringComparison.OrdinalIgnoreCase) == true) stage.Skill = "expert";

            return stage;
        }

        public stage NumberToFull(stage stage)
        {
            // Weather translations.
            if (String.Equals(stage.Weather, "0", StringComparison.OrdinalIgnoreCase) == true) stage.Weather = "dry";
            if (String.Equals(stage.Weather, "1", StringComparison.OrdinalIgnoreCase) == true) stage.Weather = "random";
            if (String.Equals(stage.Weather, "2", StringComparison.OrdinalIgnoreCase) == true) stage.Weather = "bad";

            // Tyres translation.
            if (String.Equals(stage.Tyres, "0", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "tarmac dry";
            if (String.Equals(stage.Tyres, "1", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "tarmac intermediate";
            if (String.Equals(stage.Tyres, "2", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "tarmac wet";
            if (String.Equals(stage.Tyres, "3", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "gravel dry";
            if (String.Equals(stage.Tyres, "4", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "gravel intermediate";
            if (String.Equals(stage.Tyres, "5", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "gravel wet";
            if (String.Equals(stage.Tyres, "6", StringComparison.OrdinalIgnoreCase) == true) stage.Tyres = "snow";

            // Conditions translation.
            if (String.Equals(stage.Conditions, "0", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "crisp";
            if (String.Equals(stage.Conditions, "1", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "hazy";
            if (String.Equals(stage.Conditions, "2", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "norain";
            if (String.Equals(stage.Conditions, "3", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "lightrain";
            if (String.Equals(stage.Conditions, "4", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "heavyrain";
            if (String.Equals(stage.Conditions, "5", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "nosnow";
            if (String.Equals(stage.Conditions, "6", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "lightsnow";
            if (String.Equals(stage.Conditions, "7", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "heavysnow";
            if (String.Equals(stage.Conditions, "8", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "lightfog";
            if (String.Equals(stage.Conditions, "9", StringComparison.OrdinalIgnoreCase) == true) stage.Conditions = "heavyfog";

            // Sky translation.
            if (String.Equals(stage.Sky, "0", StringComparison.OrdinalIgnoreCase) == true) stage.Sky = "clear";
            if (String.Equals(stage.Sky, "1", StringComparison.OrdinalIgnoreCase) == true) stage.Sky = "partcloud";
            if (String.Equals(stage.Sky, "2", StringComparison.OrdinalIgnoreCase) == true) stage.Sky = "lightcloud";
            if (String.Equals(stage.Sky, "3", StringComparison.OrdinalIgnoreCase) == true) stage.Sky = "heavycloud";

            // TimeOfDay translation.
            if (String.Equals(stage.TimeOfDay, "0", StringComparison.OrdinalIgnoreCase) == true) stage.TimeOfDay = "morning";
            if (String.Equals(stage.TimeOfDay, "1", StringComparison.OrdinalIgnoreCase) == true) stage.TimeOfDay = "noon";
            if (String.Equals(stage.TimeOfDay, "2", StringComparison.OrdinalIgnoreCase) == true) stage.TimeOfDay = "evening";

            // Surface translation.
            if (String.Equals(stage.Surface, "0", StringComparison.OrdinalIgnoreCase) == true) stage.Surface = "dry";
            if (String.Equals(stage.Surface, "1", StringComparison.OrdinalIgnoreCase) == true) stage.Surface = "damp";
            if (String.Equals(stage.Surface, "2", StringComparison.OrdinalIgnoreCase) == true) stage.Surface = "wet";

            // Track translation.
            if (String.Equals(stage.Track, "0", StringComparison.OrdinalIgnoreCase) == true) stage.Track = "new";
            if (String.Equals(stage.Track, "1", StringComparison.OrdinalIgnoreCase) == true) stage.Track = "normal";
            if (String.Equals(stage.Track, "2", StringComparison.OrdinalIgnoreCase) == true) stage.Track = "worn";

            // Skill translation.
            if (String.Equals(stage.Skill, "1", StringComparison.OrdinalIgnoreCase) == true) stage.Skill = "inexperienced";
            if (String.Equals(stage.Skill, "2", StringComparison.OrdinalIgnoreCase) == true) stage.Skill = "proficient";
            if (String.Equals(stage.Skill, "3", StringComparison.OrdinalIgnoreCase) == true) stage.Skill = "competent";
            if (String.Equals(stage.Skill, "4", StringComparison.OrdinalIgnoreCase) == true) stage.Skill = "skilled";
            if (String.Equals(stage.Skill, "5", StringComparison.OrdinalIgnoreCase) == true) stage.Skill = "expert";

            return stage;
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

                // We default all of the struct fields to "", for style.
                //rallyStructs.stage temp = new rallyStructs.stage();
                //temp = SRPstruct.DefaultStage(stages[SSnumber]);
                //SRPstruct.CopyStage(stages[SSnumber],temp);
                

                // We populate the stage structs. We also join every word after the "key word" at the start of each line when needed.
                if (isServiceLine == true) stages[SSnumber].Servicetime = netWords[1];
                if (isMechanicsLine == true) stages[SSnumber].Mechanics = netWords[1];
                if (isSkillLine == true) stages[SSnumber].Skill = netWords[1];
                if (isWeatherLine == true) stages[SSnumber].Weather = netWords[1];
                if (isTyresLine == true)
                {
                    if (netWordsCount == 2) stages[SSnumber].Tyres = netWords[1];
                    if (netWordsCount >= 3) stages[SSnumber].Tyres = (netWords[1] + " " + netWords[2]);
                }
                if (isConditionsLine == true) stages[SSnumber].Conditions = netWords[1];
                if (isSkyLine == true) stages[SSnumber].Sky = netWords[1];
                if (isTimeOfDayLine == true) stages[SSnumber].TimeOfDay = netWords[1];
                if (isSurfaceLine == true) stages[SSnumber].Surface = netWords[1];
                if (isTrackLine == true) stages[SSnumber].Track = netWords[1];
                if (isSetupLine == true) stages[SSnumber].Setup = netWords[1];
                if (isHotlapLine == true) stages[SSnumber].Hotlap = netWords[1];
                if (isStageLine == true)
                {
                    if (netWordsCount == 2) stages[SSnumber].Stagenn = netWords[1];
                    if (netWordsCount >= 3) // If there is a label, the whole label must be joined and stored in the Stagelabel field.
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

        public List<stage> RallyPartialToFull(List<stage> stages, int totalstagenumber) // Translates a whole rally (SRP) from partial to full notation.
        {
            for (int i = 0; i < totalstagenumber; i++) PartialToFull(stages[i]);
            return stages;
        }

        public List<stage> NewRallyPartialToFull(List<stage> stages, int totalstagenumber) // Translates a whole rally (SRP) from partial to full notation.
        {
            for (int i = 0; i < totalstagenumber; i++) NewPartialToFull(stages[i]);
            return stages;
        }

        public void WriteSRP(List<stage> stages, int totalstagenumber, string filepath)
        {
            using (StreamWriter fileCreator = File.CreateText(filepath))
            {
                fileCreator.Write("");
                fileCreator.Close();
            }

            for (int i = 0; i < totalstagenumber; i++)
                WriteStage(stages[i], filepath, i + 1);
            
        }

    }
}
