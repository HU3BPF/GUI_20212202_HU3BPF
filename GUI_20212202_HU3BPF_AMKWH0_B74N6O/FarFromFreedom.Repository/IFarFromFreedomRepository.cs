using FarFromFreedom.Model;

namespace FarFromFreedom.Repository
{
    public interface IFarFromFreedomRepository
    {
        IGameModel LoadGame(string filename);
        void SaveGame(IGameModel gameModel, string filename);
    }
}