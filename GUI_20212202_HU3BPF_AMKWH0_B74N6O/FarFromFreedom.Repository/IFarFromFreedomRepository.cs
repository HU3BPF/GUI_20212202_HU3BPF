using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarFromFreedom.Repository
{
    public interface IFarFromFreedomRepository<TGameModel, THighScore>
    {
        TGameModel LoadGame(string filename);
        void SaveGame(TGameModel gameModel, string filename);
        List<THighScore> LoadHighScore();
        void SaveHighScore(THighScore highscore);
    }
}
