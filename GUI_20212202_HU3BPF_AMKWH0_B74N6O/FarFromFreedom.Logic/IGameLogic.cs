using FarFromFreedom.Model;
using FarFromFreedom.Model.Characters;
using System.Collections.Generic;
using System.Windows.Input;

namespace FarFromFreedom.Logic
{
    public interface IGameLogic
    {
        int CurrentLevel { get; }
        int CurrentRoom { get; }

        void BulletMove();
        void EnemyDamaged();
        void EnemyDestroy();
        void EnemyHit();
        bool EnemyIsCollision(Queue<Enemy> queue, Enemy enemy);
        void EnemyMove();
        bool GameEnd();
        IGameModel GameLoad(string fileName);
        void GameSave(string fileName);
        void HighscoreUp(double highscore);
        void ItemPicked();
        void levelUp();
        void PLayerMove(Key key);
        int PlayerShoot(Key key, int counter);
        void RoomDown();
        void RoomUp();
    }
}