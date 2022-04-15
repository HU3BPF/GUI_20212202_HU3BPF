using System.Windows;

namespace FarFromFreedom.Model.Characters.Enemies
{
    public class FlyingEnemy : Enemy
    {
        public FlyingEnemy(Rect area, Vector speed) : base(area, speed)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        public FlyingEnemy(Rect area) : base(area)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        private readonly string name = "FlyingEnemy";
        private readonly string description = "FlyingEnemy";
        private readonly double health = 2;
        private readonly double currentHealth = 2;
        private readonly double power = 2;
    }
}
