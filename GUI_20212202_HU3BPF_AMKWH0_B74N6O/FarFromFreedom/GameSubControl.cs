using FarFromFreedom.Logic;
using FarFromFreedom.Model;
using FarFromFreedom.Renderer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        BaseControl baseControl;
        IGameModel model;
        bool initializeChecker = false;
        private MediaPlayer player;
        bool playing = true;
        List<Key> pressedKeys = new List<Key>();
        List<Key> keysThatMatters = new List<Key>()
            { Key.W, Key.S, Key.A, Key.D, Key.Up, Key.Down,Key.Right,
            Key.Left, Key.Space, Key.Enter, Key.P, Key.Escape, Key.H, Key.T };

        public void Dispose()
        {
            //this.logic = null;
            this.gameTimer?.Stop();
            this.gameTimer = null;
            this.bulletTimer?.Stop();
            this.bulletTimer = null;
        }

        public void Init(IGameModel model, BaseControl baseControl)
        {
            if (logic is null)
            {
                logic = new GameLogic(model);
            }
            this.model = model;
            
            this.baseControl = baseControl;
            Window win = Window.GetWindow(baseControl);
            if (win != null && initializeChecker == false)
            {
                MediaPlayer sound = new MediaPlayer();
                sound.Open(new Uri(Path.Combine("StoryVideo", "music.mp3"), UriKind.Relative));
                this.player = sound;
                sound.Volume = 0.4;

                sound.Play();

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
                gameTimer.Tick += TearDestroyer;
                gameTimer.Tick += DoorEnter;

                gameTimer.Tick += this.MainCharacterMove;
                gameTimer.Tick += TestButtons;
                gameTimer.Tick += this.MainCharacterShoot;
                gameTimer.Tick += MusicPlayer;
                gameTimer.Tick += EscapePress;

                bulletTimer.Tick += BulletTimer;

                gameTimer.Start();
                bulletTimer.Start();

                //win.KeyDown += this.MainCharacterMove;
                //win.KeyDown += TestButtons;
                //win.KeyDown += this.MainCharacterShoot;
                //win.KeyDown += MusicPlayer;
                //win.KeyDown += EscapePress;
                win.KeyDown += PutKeyToList;
                win.KeyUp += RemoveKeyFromList;
                initializeChecker = true;
            }
        }

        private void RemoveKeyFromList(object sender, KeyEventArgs e)
        {
            if (this.keysThatMatters.Contains(e.Key) && this.pressedKeys.Contains(e.Key))
            {
                this.pressedKeys.Remove(e.Key);
            }
        }

        private void PutKeyToList(object sender, KeyEventArgs e)
        {
            if (this.keysThatMatters.Contains(e.Key) && !this.pressedKeys.Contains(e.Key))
            {
                this.pressedKeys.Add(e.Key);
            }
        }

        private void EscapePress(object? sender, EventArgs e)
        {
            //if (e.Key == Key.Escape)
            //{
            //    this.bulletTimer.Stop();
            //    this.gameTimer.Stop();
            //    this.counterTimer = 0;
            //    string userName = "Teszt";
            //    this.logic.GameSave();
            //}
        }

        private void MusicPlayer(object? sender, EventArgs e)
        {
            if (this.pressedKeys.Contains(Key.P)) 
            {
                this.pressedKeys.Remove(Key.P);
                if (playing)
                {
                    player.Pause();
                }
                else
                {
                    player.Play();
                }
                playing = !playing;
            }
        }

        private void TearDestroyer(object? sender, EventArgs e)
        {
            logic?.DisposeOutOFBoundsTears();
        }

        private void TestButtons(object? sender, EventArgs e)
        {
            if (this.pressedKeys.Contains(Key.H))
            {
                this.pressedKeys.Remove(Key.H);
                MessageBox.Show("X: " + this.model.Character.Area.Rect.X + "\nY: " + this.model.Character.Area.Rect.Y);
            }
            if (this.pressedKeys.Contains(Key.T))
            {
                this.pressedKeys.Remove(Key.T);
                logic.GameSave();
            }
        }

        private void DoorEnter(object? sender, EventArgs e)
        {
            int? roomid = logic?.DoorIntersect();
            if (roomid != -1 && roomid != null)
            {

                baseControl.ChangeModel(logic?.ChangeRoom((int)roomid));
                //MessageBox.Show(roomid.ToString());
            }
        }

        private void DoorGenerator(object? sender, EventArgs e)
        {
            logic?.GenerateDoors();
        }

        private async void MainCharacterMove(object? sender, EventArgs e)
        {
            if (this.pressedKeys.Contains(Key.Up))
            {
                logic?.PLayerMove(Key.Up);
            }
            else if (this.pressedKeys.Contains(Key.Down))
            {
                logic?.PLayerMove(Key.Down);
            }
            if (this.pressedKeys.Contains(Key.Left))
            {
                logic?.PLayerMove(Key.Left);
            } 
            else if (this.pressedKeys.Contains(Key.Right))
            {
                logic?.PLayerMove(Key.Right);
            }
        }

        private async void MainCharacterShoot(object? sender, EventArgs e)
        {
            int w = this.pressedKeys.Contains(Key.W) ? this.pressedKeys.IndexOf(Key.W) : 99999;
            int a = this.pressedKeys.Contains(Key.A) ? this.pressedKeys.IndexOf(Key.A) : 99999;
            int s = this.pressedKeys.Contains(Key.S) ? this.pressedKeys.IndexOf(Key.S) : 99999;
            int d = this.pressedKeys.Contains(Key.D) ? this.pressedKeys.IndexOf(Key.D) : 99999;
            int min = (new int[4] { w, a, s, d }).Min();
            if (counterTimer >= 2 && min != 99999)
            {
                counterTimer = (int)logic?.PlayerShoot(this.pressedKeys[min], counterTimer);
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
            if (this.logic.EnemyHit())
            {
                Random r = new Random();
                MediaPlayer sound = new MediaPlayer();
                sound.Open(new Uri(Path.Combine("StoryVideo", $"Hurt_grunt_{r.Next(0,3)}.wav"), UriKind.Relative));
                sound.Play();
            }
            
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

                MediaPlayer sound = new MediaPlayer();
                sound.Open(new Uri(Path.Combine("StoryVideo", "Gobby_dies_new.wav"), UriKind.Relative));
                sound.Play();
                MessageBox.Show("Game ended.");
                gameTimer.Stop();
            }
        }

        private async void EnemyMove(object sender, EventArgs e)
        {
            this.logic?.EnemyMove();
        }
    }
    /*TODO:
     * 
     * 
        boss room trapdoor -> placehodler image, spawn a szoba közepe, felé
        xml ek frissítése (2,3)
        levelek átvitele 

        paralel 

        esc: 
	        megállnak a timerek és az input handle kicsit más lesz 
	        előjön az image
	        lehet választania continue és a save and exit között 
*/
}
