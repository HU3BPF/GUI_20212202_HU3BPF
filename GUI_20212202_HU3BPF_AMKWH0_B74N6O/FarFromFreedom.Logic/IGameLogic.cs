using FarFromFreedom.Model.Characters;

namespace FarFromFreedom.Logic
{
    public interface IGameLogic
    {
        void EnemyHit(MainCharacter character);
        void EnemyMove(MainCharacter character);
        bool GameEnd(MainCharacter character);
        void ItemPicked(MainCharacter character);
        void PLayerMove(MainCharacter player);
        void PlayerShoot(MainCharacter PlayerShoot);
    }
}