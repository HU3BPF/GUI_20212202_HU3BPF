using FarFromFreedom.Model;
using System.Collections.Generic;

namespace FarFromFreedom.Repository
{
    public interface IFarFromFreedomRepository
    {
        Dictionary<string, IGameModel> gameModelMap { get; set; }
        IGameModel LoadGame(string filename);
        void SaveGame(IGameModel gameModel, string filename);
    }
}