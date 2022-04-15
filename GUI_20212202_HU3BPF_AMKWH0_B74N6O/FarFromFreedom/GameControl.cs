using FarFromFreedom.Logic;
using FarFromFreedom.Model;
using FarFromFreedom.Renderer;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace FarFromFreedom
{
    public class GameControl : FrameworkElement
    {
        private IGameModel gameModel = new GameModel();
        private GameLogic gameLogic = new GameLogic();
        private GameRenderer renderer = new GameRenderer(new GameModel());
        private DispatcherTimer characterTimer;

        public GameControl(IGameModel model)
        {
            this.gameModel = model;
            gameLogic = new GameLogic(model);
            //renderer = new GameRenderer(gameLogic.Map);
            renderer = new GameRenderer(model);

            this.Loaded += GameLoader;

        }

        private void Win_KeyDown(object sender, KeyEventArgs e)
        {
            gameLogic.PLayerMove(e.Key);
            this.InvalidateVisual();
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

        private void GameLoader(object sender, RoutedEventArgs e)
        {
            Window win = Window.GetWindow(this);
            if (win != null)
            {
                characterTimer = new DispatcherTimer();
                this.characterTimer.Interval = TimeSpan.FromMilliseconds(100);
                characterTimer.Tick += this.Ticktimer_MainCharacter;
                this.characterTimer.Start();

                win.KeyDown += this.Win_KeyDown;
            }
        }

        private void Ticktimer_MainCharacter(object sender, EventArgs e)
        {
            this.InvalidateVisual();
        }

    }
}
