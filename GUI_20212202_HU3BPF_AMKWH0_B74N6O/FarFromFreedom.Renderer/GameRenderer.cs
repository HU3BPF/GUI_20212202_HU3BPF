using FarFromFreedom.Model;
using System.Windows;
using System.Windows.Media;

namespace FarFromFreedom.Renderer
{
    public class GameRenderer : FrameworkElement
    {
        public GameRenderer(IGameModel model)
        {
            this.model = model;
        }

        private IGameModel model;
    }
}
