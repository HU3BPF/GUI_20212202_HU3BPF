using FarFromFreedom.Model;
using FarFromFreedom.Model.Characters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace FarFromFreedom.Repository
{
    public class FarFromFreedomRepository 
    {
        public IGameModel LoadGame(string filename)
        {
            IGameModel gameModel = new GameModel(new MainCharacter("Dobby", "nincs", 10, 10, 10, 10, new Rect(new Point(10, 10), new Size(10, 25)), new Vector(1, 1)));
            string json = File.ReadAllText($"{filename}.json");
            json.

            if ("\"Character\": {{" == json.)
            {

            }


            MainCharacter a = JsonConvert.DeserializeObject<MainCharacter>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.None,
                MissingMemberHandling = MissingMemberHandling.Ignore,

            });
            return gameModel;
        }

        public List<SavedGame> LoadHighScore(SavedGame savedGame)
        {
            throw new NotImplementedException();
        }

        public void SaveGame(IGameModel gameModel, string filename)
        {
            string saveDate = DateTime.Now.Year.ToString() + ".";
            saveDate += DateTime.Now.Month.ToString() + ".";
            saveDate += DateTime.Now.Day.ToString() + "_";
            saveDate += DateTime.Now.Hour.ToString() + "H";
            saveDate += DateTime.Now.Minute.ToString() + "M";
            saveDate = saveDate.Trim();
            string jsonData = JsonConvert.SerializeObject(gameModel, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.None,
                TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple,
            });
            File.WriteAllText($"{filename}_{saveDate}.json", jsonData);
        }
            
        public void LoadGame(IGameModel gameModel, string filename)
        {
            using (StreamWriter r = new StreamWriter($"{filename + DateTime.Now}.json"))
            {
                r.WriteLine(gameModel);
            }
        }

        public void SaveHighScore(SavedGame highscore)
        {
            throw new NotImplementedException();
        }
    }
}
