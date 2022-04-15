using System.Windows;

namespace FarFromFreedom.Model.Characters.Enemies
{
    public class PenguinEnemy : Enemy
    {
        public PenguinEnemy(Rect area, Vector speed) : base(area, speed)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        public PenguinEnemy(Rect area) : base(area)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        private readonly string name = "PenguinEnemy";
        private readonly string description = "PenguinEnemy";
        private readonly double health = 2;
        private readonly double currentHealth = 2;
        private readonly double power = 2;
    }
}
