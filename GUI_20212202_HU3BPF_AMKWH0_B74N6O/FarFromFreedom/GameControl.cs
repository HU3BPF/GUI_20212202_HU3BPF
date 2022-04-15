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
        private DispatcherTimer gameTimer;

        public GameControl(IGameModel model)
        {
            this.gameModel = model;
            gameLogic = new GameLogic(model);
            //renderer = new GameRenderer(gameLogic.Map);
            renderer = new GameRenderer(model);

            this.Loaded += GameLoader;

        }

        private void MainCharacterMove(object sender, KeyEventArgs e)
        {
            gameLogic.PLayerMove(e.Key);
            InvalidateVisual();
        }

        private void MainCharacterShoot(object sender, KeyEventArgs e)
        {
            gameLogic.PLayerMove(e.Key);
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

                gameTimer = new DispatcherTimer();
                this.gameTimer.Interval = TimeSpan.FromMilliseconds(150);
                gameTimer.Tick += this.EnemyMove;
                gameTimer.Tick += this.EnemyHit;
                gameTimer.Tick += this.GameEnded;
                this.gameTimer.Start();

                win.KeyDown += this.MainCharacterMove;
            }
        }



        private void EnemyHit(object sender, EventArgs e)
        {
           //this.gameLogic.EnemyHit();
        }
        
        private void GameEnded(object sender, EventArgs e)
        {
            if (this.gameLogic.GameEnd())
            {
                var w = Application.Current.Windows[0];
                w.Hide();
                MessageBox.Show("Game ended.");
                gameTimer.Stop();
            }
        }

        private void EnemyMove(object sender, EventArgs e)
        {
            this.gameLogic.EnemyMove();
        }

    }
}
