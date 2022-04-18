using FarFromFreedom.Model;
using FarFromFreedom.Model.Characters;
using System.Collections.Generic;
using System.Windows.Input;

namespace FarFromFreedom.Logic
{
    public interface IGameLogic
    {
        void BulletMove();
        void EnemyDamaged();
        void EnemyDestroy();
        void EnemyHit();
        bool EnemyIsCollision(Queue<Enemy> queue, Enemy enemy);
        void EnemyMove();
        bool GameEnd();
        IGameModel GameLoader(string fileName);
        void ItemPicked();
        void PLayerMove(Key key);
        int PlayerShoot(Key key, int counter);
        void PlayerShoot(MainCharacter PlayerShoot);
    }
}