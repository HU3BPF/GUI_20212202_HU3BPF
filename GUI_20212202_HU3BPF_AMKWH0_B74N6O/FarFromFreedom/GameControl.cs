using FarFromFreedom.Logic;
using FarFromFreedom.Model;
using FarFromFreedom.Renderer;
using System.Windows;
using System.Windows.Media;

namespace FarFromFreedom
{
    public class GameControl : FrameworkElement
    {
        private IGameModel gameModel;
        private GameLogic gameLogic;
        private GameRenderer renderer;

        public GameControl(IGameModel model)
        {
            this.gameModel = model;
        
        }

        public GameControl()
        {
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            renderer = new GameRenderer(gameModel);
            if (this.renderer != null)
            {
                drawingContext.DrawDrawing(this.renderer.BuildDrawing());
            }
        }
    }
}
