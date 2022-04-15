using System.Windows;

namespace FarFromFreedom.Model.Characters.Enemies
{
    public class PugEnemy : Enemy
    {
        public PugEnemy(Rect area, Vector speed) : base(area, speed)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        public PugEnemy(Rect area) : base(area)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        private readonly string name = "PugEnemy";
        private readonly string description = "PugEnemy";
        private readonly double health = 2;
        private readonly double currentHealth = 2;
        private readonly double power = 2;
    }
}
