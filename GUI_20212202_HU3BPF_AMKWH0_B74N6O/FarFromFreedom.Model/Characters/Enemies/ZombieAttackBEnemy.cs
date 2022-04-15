using System.Windows;

namespace FarFromFreedom.Model.Characters.Enemies
{
    public class ZombieAttackBEnemy : Enemy
    {
        public ZombieAttackBEnemy(Rect area, Vector speed) : base(area, speed)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        public ZombieAttackBEnemy(Rect area) : base(area)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        private readonly string name = "ZombieAttackBEnemy";
        private readonly string description = "ZombieAttackBEnemy";
        private readonly double health = 2;
        private readonly double currentHealth = 2;
        private readonly double power = 2;
    }
}
