﻿using FarFromFreedom.Model;
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
            IGameModel gameModel = new GameModel(new Model.Characters.MainCharacter("Dobby", "nincs", 10, 10, 10, 10, new Rect(new Point(10, 10), new Size(10, 25)), new Vector(1, 1)));

            using (StreamReader r = new StreamReader($"{filename}.json"))
            {
                string json = r.ReadToEnd();
                
                gameModel = JsonConvert.DeserializeObject<IGameModel>(json, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.None,
                    MissingMemberHandling = MissingMemberHandling.Ignore,

                });
            }

            return gameModel;
        }

        public List<SavedGame> LoadHighScore(SavedGame savedGame)
        {
            throw new NotImplementedException();
        }

        public void SaveGame(IGameModel gameModel, string filename)
        {
            using (StreamWriter r = new StreamWriter($"{filename + DateTime.Now}.json"))
            {
                r.WriteLine(gameModel);
            }
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
