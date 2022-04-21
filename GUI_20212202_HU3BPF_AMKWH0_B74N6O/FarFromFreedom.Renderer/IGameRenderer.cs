using FarFromFreedom.Model;
using System.Windows.Media;

namespace FarFromFreedom.Renderer
{
    public interface IGameRenderer
    {
        DrawingGroup BuildDrawing();
        void GameModelChanged(IGameModel gameModel);
    }
}