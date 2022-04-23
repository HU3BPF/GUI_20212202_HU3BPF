﻿using FarFromFreedom.Logic;
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
    internal class BaseControl : FrameworkElement
    {
        IModel model;
        public IGameLogic gameLogic = new GameLogic();
        public IGameRenderer renderer;
        private DispatcherTimer gameTimer;
        private DispatcherTimer bulletTimer;
        private int counterTimer = 0;

        //public BaseControl(IModel model)
        //{
        //    //gameLogic = new GameLogic(model);
        //    ////renderer = new GameRenderer(gameLogic.Map);
        //    //renderer = new GameRenderer(model);

        //    //this.Loaded += GameLoader;

        //}

        public BaseControl()
        {
            this.model = new MenuModel();
            this.renderer = new MenuRenderer(this.model as IMenuModel);
        }

        public IGameModel GameLoad(string fileName)
        {
            return gameLogic.GameLoad(fileName);
        }

        public void GameSave(string fileName)
        {
            gameLogic.GameSave(fileName);
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

                this.gameTimer = new DispatcherTimer();
                this.bulletTimer = new DispatcherTimer();

                this.gameTimer.Interval = TimeSpan.FromMilliseconds(30);
                this.bulletTimer.Interval = TimeSpan.FromSeconds(0.5);

                this.gameTimer.Tick += this.EnemyMove;
                this.gameTimer.Tick += this.EnemyHit;
                this.gameTimer.Tick += this.BulletMove;
                this.gameTimer.Tick += this.EnemyDamaged;
                this.gameTimer.Tick += this.EnemyDestroy;
                this.gameTimer.Tick += this.ItemPickedUp;
                this.gameTimer.Tick += this.GameEnded;
                this.bulletTimer.Tick += this.BulletTimer;

                this.gameTimer.Start();
                this.bulletTimer.Start();

                win.KeyDown += this.MainCharacterMove;
                win.KeyDown += this.MainCharacterShoot;
            }
        }

        private async void MainCharacterMove(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.Left || e.Key == Key.Right)
            {
                gameLogic.PLayerMove(e.Key);
            }
        }

        private async void MainCharacterShoot(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W || e.Key == Key.S || e.Key == Key.A || e.Key == Key.D)
            {
                if (counterTimer >= 2)
                {
                    counterTimer = gameLogic.PlayerShoot(e.Key, counterTimer);
                }
            }
        }

        public void RoomLoad(object sender, EventArgs e)
        {
            if (true)
            {
                this.gameLogic.RoomUp();
            }
            else
            {
                this.gameLogic.RoomDown();
            }
        }

        private async void EnemyDestroy(object sender, EventArgs e)
        {
            this.gameLogic.EnemyDestroy();
        }

        private async void BulletTimer(object sender, EventArgs e)
        {
            this.counterTimer++;
        }

        private async void EnemyDamaged(object sender, EventArgs e)
        {
            this.gameLogic.EnemyDamaged();
        }

        private async void ItemPickedUp(object sender, EventArgs e)
        {
            this.gameLogic.ItemPicked();
        }

        private async void EnemyHit(object sender, EventArgs e)
        {
            //this.gameLogic.EnemyHit();
        }

        private async void BulletMove(object sender, EventArgs e)
        {
            this.gameLogic.BulletMove();
        }

        private async void GameEnded(object sender, EventArgs e)
        {
            if (this.gameLogic.GameEnd())
            {
                var w = Application.Current.Windows[0];
                w.Hide();
                MessageBox.Show("Game ended.");
                gameTimer.Stop();
            }
        }

        private async void EnemyMove(object sender, EventArgs e)
        {
            this.gameLogic.EnemyMove();
            InvalidateVisual();
        }

    }
}