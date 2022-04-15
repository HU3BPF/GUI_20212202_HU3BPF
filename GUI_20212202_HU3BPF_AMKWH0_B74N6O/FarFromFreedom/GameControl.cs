using FarFromFreedom.Logic;
using FarFromFreedom.Model;
using FarFromFreedom.Renderer;
using System.Windows;
using System.Windows.Media;

namespace FarFromFreedom
{
    public class GameControl : FrameworkElement
    {
        private IGameModel gameModel = new GameModel();
        private GameLogic gameLogic = new GameLogic();
        private GameRenderer renderer = new GameRenderer(new GameModel());

        public GameControl(IGameModel model)
        {
            this.gameModel = model;
            gameLogic = new GameLogic();
            //renderer = new GameRenderer(gameLogic.Map);
            renderer = new GameRenderer(model);

        }

        public GameControl()
        {
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.renderer != null)
            {
                drawingContext.DrawDrawing(this.renderer.BuildDrawing());
            }
        }
    }
}
