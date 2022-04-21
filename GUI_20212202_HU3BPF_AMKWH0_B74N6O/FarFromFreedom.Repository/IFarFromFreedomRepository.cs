using FarFromFreedom.Model;
using System.Collections.Generic;

namespace FarFromFreedom.Repository
{
    public interface IFarFromFreedomRepository
    {
        List<Dictionary<int, IGameModel>> GameModelMap { get; }

        IGameModel LoadGame(string fileName);
        void SaveGame(IGameModel gameModel, string filename);
    }
}