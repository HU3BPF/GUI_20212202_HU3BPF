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

            string json = File.ReadAllText($"{filename}.json");

            GameModel gameModel = JsonConvert.DeserializeObject<GameModel>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
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
                TypeNameHandling = TypeNameHandling.All,
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
