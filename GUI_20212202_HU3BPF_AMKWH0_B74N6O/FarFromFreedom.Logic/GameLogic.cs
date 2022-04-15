using FarFromFreedom.Model;
using System;

namespace FarFromFreedom.Logic
{
    public class GameLogic : IGameModelLogic, IGameLogic
    {
        public IGameModel Map { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void EnemyMove(Direction enemy)
        {
            throw new NotImplementedException();
        }

        public void EnemyShoot()
        {
            throw new NotImplementedException();
        }

        public bool GameEnd()
        {
            throw new NotImplementedException();
        }

        public void ItemPicked()
        {
            throw new NotImplementedException();
        }

        public void PLayerMove(Direction player)
        {
            throw new NotImplementedException();
        }

        public void PlayerShoot(Direction PlayerShoot)
        {
            throw new NotImplementedException();
        }
    }
}
