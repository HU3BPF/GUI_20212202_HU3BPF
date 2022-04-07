using FarFromFreedom.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarFromFreedom.Repository
{
    public class FarFromFreedomRepository : IFarFromFreedomRepository<IGameModel, SavedGame>
    {
        public IGameModel LoadGame(string filename)
        {
            IGameModel gameModel;
            using (StreamReader r = new StreamReader($"{filename}.json"))
            {
                string json = r.ReadToEnd();
                gameModel = JsonConvert.DeserializeObject<IGameModel>(json, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.None,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                });
                r.Close();
            }
            return gameModel;
        }

        public List<SavedGame> LoadHighScore()
        {
            throw new NotImplementedException();
        }

        public void SaveGame(IGameModel gameModel, string filename)
        {
            throw new NotImplementedException();
        }

        public void SaveHighScore(SavedGame highscore)
        {
            throw new NotImplementedException();
        }
    }
}
