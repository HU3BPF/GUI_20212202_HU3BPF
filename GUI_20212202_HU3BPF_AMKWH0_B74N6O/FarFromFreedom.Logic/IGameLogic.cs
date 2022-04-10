namespace FarFromFreedom.Logic
{
    public enum Direction
    {
        Up, Down, Left, Right
    }
    public interface IGameLogic
    {
        void PLayerMove(Direction player);

        void EnemyMove(Direction enemy);

        void PlayerShoot(Direction PlayerShoot);

        void EnemyShoot();

        bool GameEnd();

        void ItemPicked();
    }
}
