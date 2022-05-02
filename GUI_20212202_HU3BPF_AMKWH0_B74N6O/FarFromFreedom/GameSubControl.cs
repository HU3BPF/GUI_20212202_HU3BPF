using FarFromFreedom.Logic;
using FarFromFreedom.Model;
using FarFromFreedom.Renderer;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace FarFromFreedom
{
    public class GameSubControl
    {
        IGameLogic? logic;
        public DispatcherTimer? gameTimer;
        DispatcherTimer? bulletTimer;
        private int counterTimer = 0;

        public void Dispose()
        {
            this.logic = null;
            this.gameTimer?.Stop();
            this.gameTimer = null;
            this.bulletTimer?.Stop();
            this.bulletTimer = null;
        }

        public void Init(IGameModel model, BaseControl baseControl)
        {
            logic = new GameLogic(model);
            Window win = Window.GetWindow(baseControl);
            if (win != null)
            {

                gameTimer = new DispatcherTimer();
                bulletTimer = new DispatcherTimer();

                gameTimer.Interval = TimeSpan.FromMilliseconds(30);
                bulletTimer.Interval = TimeSpan.FromSeconds(0.5);

                gameTimer.Tick += EnemyMove;
                gameTimer.Tick += EnemyHit;
                gameTimer.Tick += BulletMove;
                gameTimer.Tick += EnemyDamaged;
                gameTimer.Tick += EnemyDestroy;
                gameTimer.Tick += ItemPickedUp;
                gameTimer.Tick += GameEnded;
                gameTimer.Tick += DoorGenerator;
                gameTimer.Tick += DoorEnter;
                
                bulletTimer.Tick += BulletTimer;

                gameTimer.Start();
                bulletTimer.Start();

                win.KeyDown += this.MainCharacterMove;
                win.KeyDown += this.MainCharacterShoot;
            }
        }

        private void DoorEnter(object? sender, EventArgs e)
        {
            int? roomid = logic?.DoorIntersect();
            if (roomid != -1)
            {
                MessageBox.Show(roomid.ToString());
            }
        }

        private void DoorGenerator(object? sender, EventArgs e)
        {
            logic?.GenerateDoors();
        }

        private async void MainCharacterMove(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.Left || e.Key == Key.Right)
            {
                logic?.PLayerMove(e.Key);
            }
        }

        private async void MainCharacterShoot(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W || e.Key == Key.S || e.Key == Key.A || e.Key == Key.D)
            {
                if (counterTimer >= 2)
                {
                    counterTimer = (int)logic?.PlayerShoot(e.Key, counterTimer);
                }
            }
        }

        public void RoomLoad(object sender, EventArgs e)
        {
            if (true)
            {
                this.logic?.RoomUp();
            }
            else
            {
                this.logic?.RoomDown();
            }
        }

        private async void EnemyDestroy(object sender, EventArgs e)
        {
            this.logic?.EnemyDestroy();
        }

        private async void BulletTimer(object sender, EventArgs e)
        {
            this.counterTimer++;
        }

        private async void EnemyDamaged(object sender, EventArgs e)
        {
            this.logic?.EnemyDamaged();
        }

        private async void ItemPickedUp(object sender, EventArgs e)
        {
            this.logic?.ItemPicked();
        }

        private async void EnemyHit(object sender, EventArgs e)
        {
            this.logic?.EnemyHit();
        }

        private async void BulletMove(object sender, EventArgs e)
        {
            this.logic?.BulletMove();
        }

        private async void GameEnded(object sender, EventArgs e)
        {
            if ((bool)this.logic?.GameEnd())
            {
                var w = Application.Current.Windows[0];
                w.Hide();
                MessageBox.Show("Game ended.");
                gameTimer.Stop();
            }
        }

        private async void EnemyMove(object sender, EventArgs e)
        {
            this.logic?.EnemyMove();
        }
    }
}
