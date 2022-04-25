using FarFromFreedom.Logic;
using FarFromFreedom.Model;
using FarFromFreedom.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace FarFromFreedom
{
    public class BaseControl : FrameworkElement
    {
        IModel model;
        //public IGameLogic gameLogic = new GameLogic();
        public IGameRenderer renderer;
        private DispatcherTimer gameTimer;
        private DispatcherTimer bulletTimer;
        private int counterTimer = 0;
        private MenuSubControl menuSubControl = new MenuSubControl();
        private GameSubControl gameSubControl = new GameSubControl();


        public BaseControl()
        {
            this.ChangeModel(new MenuModel());
            //this.model = new MenuModel();
            //this.renderer = new MenuRenderer(this.model as IMenuModel);
            this.menuSubControl.Init((IMenuModel)this.model);
            

            this.Loaded += GameLoader;
        }

        public IGameModel GameLoad(string fileName)
        {
            //return gameLogic.GameLoad(fileName);
            return new GameModel();
        }

        public void GameSave(string fileName)
        {
            //gameLogic.GameSave(fileName);
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

                //this.gameTimer = new DispatcherTimer();
                //this.bulletTimer = new DispatcherTimer();

                //this.gameTimer.Interval = TimeSpan.FromMilliseconds(30);
                //this.bulletTimer.Interval = TimeSpan.FromSeconds(0.5);

                //this.gameTimer.Tick += this.EnemyMove;
                //this.gameTimer.Tick += this.EnemyHit;
                //this.gameTimer.Tick += this.BulletMove;
                //this.gameTimer.Tick += this.EnemyDamaged;
                //this.gameTimer.Tick += this.EnemyDestroy;
                //this.gameTimer.Tick += this.ItemPickedUp;
                //this.gameTimer.Tick += this.GameEnded;
                //this.bulletTimer.Tick += this.BulletTimer;

                //this.gameTimer.Start();
                //this.bulletTimer.Start();

                win.KeyDown += HandleInput;
                //win.KeyDown += this.MainCharacterShoot;
            }
        }

        private void HandleInput(object sender, KeyEventArgs e)
        {
            if (this.model is IMenuModel menuModel)
            {
                if (menuModel.IsWelcomePage)
                {
                    menuModel.IsWelcomePage = false;
                    menuModel.ResetParams();
                    InvalidateVisual();
                    return;
                }

                if (this.menuSubControl.HandleInput(this, menuModel, sender, e) == 1)
                {
                    InvalidateVisual();
                }
                
            }
            else if (this.model is IGameModel gameModel)
            {
                //GameSubControl.HandleInput(gameModel, sender, e);
            }
        }

        public void ChangeModel(IModel model)
        {
            if (this.model is IMenuModel)
            {
                this.menuSubControl.Dispose();
            }
            else if (this.model is IGameModel gameModel)
            {
                this.gameSubControl.Dispose();
            }

            this.model = model;

            if (this.model is IMenuModel menuModel)
            {
                this.renderer = new MenuRenderer((IMenuModel)this.model);
                this.menuSubControl.Init((IMenuModel)this.model);
            }
            else if (this.model is IGameModel gameModel)
            {
                this.renderer = new GameRenderer((IGameModel)this.model);
                this.gameSubControl.Init((IGameModel)this.model, this);
                this.gameSubControl.gameTimer.Tick += GameTimer_ScreenRefresh;
            }

            InvalidateVisual();
        }

        private void GameTimer_ScreenRefresh(object? sender, EventArgs e)
        {
            InvalidateVisual();
        }
    }
}
