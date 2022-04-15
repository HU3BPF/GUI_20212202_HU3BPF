using System.Windows;

namespace FarFromFreedom.Model.Characters.Enemies
{
    public class ZombieAttackAEnemy : Enemy
    {
        public ZombieAttackAEnemy(Rect area, Vector speed) : base(area, speed)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        public ZombieAttackAEnemy(Rect area) : base(area)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        private readonly string name = "ZombieAttackAEnemy";
        private readonly string description = "ZombieAttackAEnemy";
        private readonly double health = 2;
        private readonly double currentHealth = 2;
        private readonly double power = 2;
    }
}
