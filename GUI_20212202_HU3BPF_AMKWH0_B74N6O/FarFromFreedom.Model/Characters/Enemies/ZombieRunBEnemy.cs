using System.Windows;

namespace FarFromFreedom.Model.Characters.Enemies
{
    public class ZombieRunBEnemy : Enemy
    {
        public ZombieRunBEnemy(Rect area, Vector speed) : base(area, speed)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        public ZombieRunBEnemy(Rect area) : base(area)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        private readonly string name = "ZombieRunBEnemy";
        private readonly string description = "ZombieRunBEnemy";
        private readonly double health = 2;
        private readonly double currentHealth = 2;
        private readonly double power = 2;
    }
}
