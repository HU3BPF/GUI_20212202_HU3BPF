using System.Collections.Generic;

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
