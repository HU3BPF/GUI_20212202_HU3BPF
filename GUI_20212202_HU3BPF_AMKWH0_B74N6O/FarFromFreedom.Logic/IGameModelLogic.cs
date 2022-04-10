using FarFromFreedom.Model;

namespace FarFromFreedom.Logic
{
    public interface IGameModelLogic
    {
        IGameModel[,] Map { get; set; }
    }
}
