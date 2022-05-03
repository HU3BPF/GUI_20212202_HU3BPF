using FarFromFreedom.Model;
using FarFromFreedom.Model.Characters;
using FarFromFreedom.Model.Characters.Enemies;
using FarFromFreedom.Model.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Linq;

namespace FarFromFreedom.Repository
{
    public class FarFromFreedomRepository : IFarFromFreedomRepository
    {
        //Az adott pályának a száma és a hozzá tartozó értéke.
        //Lista azért van mert minden level 1 lista elem és benne tartozó értékek leszenk megjelölve számmal.
        //Így vissza is tudunk menni 1 levelen egy pályára.
        public List<Dictionary<int, IGameModel>> GameModelMap => gameModelMap;

        private List<Dictionary<int, IGameModel>> gameModelMap = new List<Dictionary<int, IGameModel>>();
        private static IFarFromFreedomRepository instance = null;
        public static IFarFromFreedomRepository Instance()
        {
            if (instance == null)
            {
                instance = new FarFromFreedomRepository(1);
            }
            return instance;
        }
        private FarFromFreedomRepository(int levels)
        {
            this.LoadLevel(levels);
            for (int i = 1; i <= levels; i++)
            {
                this.LoadLevel(i);
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

        private void LoadLevel(int lvl)
        {
            Dictionary<int, IGameModel> newGameModelMap = new Dictionary<int, IGameModel>();
            //string json = File.ReadAllText($"Level{lvl}.xml");

            XDocument source = XDocument.Load(Path.Combine("Map", $"Level{lvl}.xml"));
            int key;
            GameModel tmpModel;
            
            foreach (XElement room in source.Element($"Level{lvl}").Elements("Room"))
            {
                key = int.Parse(room.Attribute("ID").Value);

                int[] neighbours = this.GetNeighbours(room);

                List<IEnemy> enemies = this.GetEnemies(room);

                List<IItem> items = this.GetItems(room);
                tmpModel = new GameModel(neighbours, lvl, key, enemies, items);

                newGameModelMap.Add(key, tmpModel);
            }
            this.GameModelMap.Add(newGameModelMap);

            //List<GameModel> gameModel = JsonConvert.DeserializeObject<List<GameModel>>(json, new JsonSerializerSettings
            //{
            //    TypeNameHandling = TypeNameHandling.All,
            //    TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple,
            //    ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            //});

            //for (int i = 0; i < gameModel.Count; i++)
            //{
            //    newGameModelMap.Add(i, gameModel[i]);
            //}

        }

        /// <summary>
        /// Loads the items in the room.
        /// </summary>
        /// <param name="room"> The room's xelemnt. </param>
        /// <returns> List of items. </returns>
        private List<IItem> GetItems(XElement room)
        {
            List<IItem> result = new List<IItem>();

            foreach (XElement obj in room.Element("Objects").Elements("Object"))
            {
                IItem tmp;
                int x, y, width, height;
                x = int.Parse(obj.Attribute("X").Value);
                y = int.Parse(obj.Attribute("Y").Value);
                width = int.Parse(obj.Attribute("Width").Value);
                height = int.Parse(obj.Attribute("Height").Value);

                switch (obj.Attribute("Type").Value)
                {
                    //case "Plyaelem":
                    //    tmp = new Pályaelem(x, y, width, height);
                    //    break;
                    default:
                        break;
                }
            }


            return result;
        }

        /// <summary>
        /// Loads the enemies from the room.
        /// </summary>
        /// <param name="room"> The room's xelemet. </param>
        /// <returns> List of enemies. </returns>
        private List<IEnemy> GetEnemies(XElement room)
        {
            List<IEnemy> result = new List<IEnemy>();

            foreach (XElement obj in room.Element("Enemies").Elements("Enemy"))
            {
                IEnemy tmp = new BatEnemy();
                int x, y, width, height;
                x = int.Parse(obj.Attribute("X").Value);
                y = int.Parse(obj.Attribute("Y").Value);
                width = int.Parse(obj.Attribute("Width").Value);
                height = int.Parse(obj.Attribute("Height").Value);
                Rect rect = new Rect(x, y, width, height);

                switch (obj.Attribute("Type").Value)
                {

                    case "Mushroom":
                        tmp = new MushroomEnemy(rect);
                        break;
                    case "Pug":
                        tmp = new PugEnemy(rect);
                        break;
                    case "Wasp":
                        tmp = new WaspEnemy(rect);
                        break;
                    case "Bat":
                        tmp = new BatEnemy(rect);
                        break;
                    case "Flying":
                        tmp = new PugEnemy(rect);
                        break;
                    case "Monster":
                        tmp = new MonsterEnemy(rect);
                        break;
                    case "Cat":
                        tmp = new CatEnemy(rect);
                        break;
                    case "ZombieRunB":
                        tmp = new ZombieRunBEnemy(rect);
                        break;
                    case "ZombieWalkCripple":
                        tmp = new ZombieWalkCrippleEnemy(rect);
                        break;
                    default:
                        break;
                }

                result.Add(tmp);
            }

            return result;
        }

        /// <summary>
        /// Loads a rooms neighbours.
        /// </summary>
        /// <param name="room"> The room's xelement. </param>
        /// <returns> Int array that represents the neighbours' ids. </returns>
        private int[] GetNeighbours(XElement room)
        {
            int[] result = new int[4];

            if (!int.TryParse(room.Element("Neighbours").Element("UpperNeighbour").Attribute("ID")?.Value, out result[0]))
            {
                result[0] = -1;
            }

            if (!int.TryParse(room.Element("Neighbours").Element("RightNeighbour").Attribute("ID")?.Value, out result[1]))
            {
                result[1] = -1;
            }

            if (!int.TryParse(room.Element("Neighbours").Element("LowerNeighbour").Attribute("ID")?.Value, out result[2]))
            {
                result[2] = -1;
            }

            if (!int.TryParse(room.Element("Neighbours").Element("LeftNeighbour").Attribute("ID")?.Value, out result[3]))
            {
                result[3] = -1;
            }

            return result;
        }

        private Dictionary<int, IGameModel> GameModelIniter(string fileName)
        {
            Dictionary<int, IGameModel> newGameModelMap = new Dictionary<int, IGameModel>();
            string json = File.ReadAllText($"{fileName}.json");

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
