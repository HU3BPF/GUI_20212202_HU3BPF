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

        private string name;
        private string description;
        private double health;
        private double currentHealth;
        private double power;
    }
}
