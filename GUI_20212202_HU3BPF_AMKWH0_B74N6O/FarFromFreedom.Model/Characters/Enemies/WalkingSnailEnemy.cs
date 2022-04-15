using System.Windows;

namespace FarFromFreedom.Model.Characters.Enemies
{
    public class WalkingSnailEnemy : Enemy
    {
        public WalkingSnailEnemy(Rect area, Vector speed) : base(area, speed)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        public WalkingSnailEnemy(Rect area) : base(area)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        private readonly string name = "WalkingSnailEnemy";
        private readonly string description = "WalkingSnailEnemy";
        private readonly double health = 2;
        private readonly double currentHealth = 2;
        private readonly double power = 2;
    }
}
