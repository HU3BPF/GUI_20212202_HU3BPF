using FarFromFreedom.Model.Characters;
using FarFromFreedom.Model.Items;

namespace FarFromFreedom.Model
{
    public interface IGameModel
    {
        Enemy BatEnemy { get; }
        Bomb Bomb { get; }
        Bootle Bootle { get; }
        MainCharacter Character { get; }
        Enemy ClamFlowerEnemy { get; }
        Coin Coin { get; }
        Enemy CutSwordEnemy { get; }
        Enemy EatingCactusEnemy { get; }
        Enemy FlyingEnemy { get; }
        Enemy FurryEnemy { get; }
        Hearth Hearth { get; }
        Enemy HippoEnemy { get; }
        Enemy LemonEnemy { get; }
        Money Money { get; }
        Enemy PandaEnemy { get; }
        Enemy PenguinEnemy { get; }
        Enemy PigEnemy { get; }
        Enemy PugEnemy { get; }
        Shield Shield { get; }
        Star Star { get; }
        Enemy ThreeEyesEnemy { get; }
        Enemy WalkingSnailEnemy { get; }
        Enemy ZombieAttackAEnemy { get; }
        Enemy ZombieAttackBEnemy { get; }
        Enemy ZombieRunBEnemy { get; }
        Enemy ZombieWalkCrippleEnemy { get; }
        Enemy ZombiGiphyEnemy { get; }

        void initLevel1(Enemy HippoEnemy, Enemy PandaEnemy, Enemy PenguinEnemy, Enemy PigEnemy, Enemy PugEnemy);
    }
}