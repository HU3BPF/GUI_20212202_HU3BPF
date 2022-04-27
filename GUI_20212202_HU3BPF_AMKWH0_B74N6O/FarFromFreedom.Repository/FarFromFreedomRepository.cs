using FarFromFreedom.Model;
using FarFromFreedom.Model.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace FarFromFreedom.Repository
{
    public class FarFromFreedomRepository : IFarFromFreedomRepository
    {
        //Az adott pályának a száma és a hozzá tartozó értéke.
        //Lista azért van mert minden level 1 lista elem és benne tartozó értékek leszenk megjelölve számmal.
        //Így vissza is tudunk menni 1 levelen egy pályára.
        public List<Dictionary<int, IGameModel>> GameModelMap => gameModelMap;

        private List<Dictionary<int, IGameModel>> gameModelMap = new List<Dictionary<int, IGameModel>>();

        public FarFromFreedomRepository(int levels, string fileName)
        {
            if (true)
            {
                gameModelMap.Add(GameModelIniter($"fileName{fileName}"));
            }
            else
            {
                for (int i = 0; i < levels; i++)
                {
                    gameModelMap.Add(GameModelIniter($"fileName{fileName}"));
                }
            }
        }

        public IGameModel LoadGame(string fileName)
        {
            string json = File.ReadAllText($"{fileName}.json");

            GameModel gameModel = JsonConvert.DeserializeObject<GameModel>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            });
            return gameModel;
        }

        public void SaveGame(IGameModel gameModel, string filename)
        {
            List<JsonConverter> jsonConverter = new List<JsonConverter>();
            jsonConverter.Add(new JsonRectConverter());
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
                Converters = jsonConverter
            });
            File.WriteAllText($"{filename}_{saveDate}.json", jsonData);
        }

        class rect2 : Rect
        {

        }

        private Dictionary<int, IGameModel> GameModelIniter(string fileName)
        {
            Dictionary<int, IGameModel> newGameModelMap = new Dictionary<int, IGameModel>();
            //string json = File.ReadAllText($"{fileName}.json");
            string json = File.ReadAllText(Path.Combine("Map", "Level1.json"));
            Rect tesztt = new Rect(5, 5, 10, 10);
            

            Rect rectr = JsonConvert.DeserializeObject<Rect>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            });

            List<GameModel> gameModel = JsonConvert.DeserializeObject<List<GameModel>>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            });

            for (int i = 0; i < gameModel.Count; i++)
            {
                newGameModelMap.Add(i, gameModel[i]);
            }

            return newGameModelMap;
        }
    }
}
