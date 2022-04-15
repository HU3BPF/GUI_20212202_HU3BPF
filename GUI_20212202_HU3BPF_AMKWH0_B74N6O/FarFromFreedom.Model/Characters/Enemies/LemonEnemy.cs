using System.Windows;

namespace FarFromFreedom.Model.Characters.Enemies
{
    public class LemonEnemy : Enemy
    {
        public LemonEnemy(Rect area, Vector speed) : base(area, speed)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        public LemonEnemy(Rect area) : base(area)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        private readonly string name = "LemonEnemy";
        private readonly string description = "LemonEnemy";
        private readonly double health = 2;
        private readonly double currentHealth = 2;
        private readonly double power = 2;
    }
}
