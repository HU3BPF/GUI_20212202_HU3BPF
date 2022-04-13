using FarFromFreedom.Model.Characters;
using FarFromFreedom.Model.Items;
using System.Collections.Generic;

namespace FarFromFreedom.Model
{
    public class GameModel : IGameModel
    {
        public GameModel(MainCharacter character) => Character = character;

        public MainCharacter Character { get; }

        //Level1
        public Enemy HippoEnemy { get; }
        public Enemy PandaEnemy { get; }
        public Enemy PenguinEnemy { get; }
        public Enemy PigEnemy { get; }
        public Enemy PugEnemy { get; }

        //Level2
        public Enemy BatEnemy { get; }
        public Enemy ClamFlowerEnemy { get; }
        public Enemy CutSwordEnemy { get; }
        public Enemy EatingCactusEnemy { get; }
        public Enemy FlyingEnemy { get; }
        public Enemy FurryEnemy { get; }
        public Enemy LemonEnemy { get; }
        public Enemy ThreeEyesEnemy { get; }
        public Enemy WalkingSnailEnemy { get; }

        //level3
        public Enemy ZombieAttackAEnemy { get; }
        public Enemy ZombieAttackBEnemy { get; }
        public Enemy ZombieRunBEnemy { get; }
        public Enemy ZombieWalkCrippleEnemy { get; }
        public Enemy ZombiGiphyEnemy { get; }

        //Items
        public Bomb Bomb => bomb;
        public Bootle Bootle => bottle;
        public Coin Coin => coin;
        public Money Money => money;
        public Hearth Hearth => hearth;
        public Shield Shield => shield;
        public Star Star => star;

        public Bomb bomb = new Bomb(new System.Windows.Rect());
        public Bootle bottle = new Bootle(new System.Windows.Rect());
        public Coin coin = new Coin(new System.Windows.Rect());
        public Money money = new Money(new System.Windows.Rect());
        public Hearth hearth = new Hearth(new System.Windows.Rect());
        public Shield shield = new Shield(new System.Windows.Rect());
        public Star star = new Star(new System.Windows.Rect());

        public void initLevel1(Enemy HippoEnemy, Enemy PandaEnemy, Enemy PenguinEnemy, Enemy PigEnemy, Enemy PugEnemy)
        {
        }
    }
}
