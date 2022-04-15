using System.Windows;

namespace FarFromFreedom.Model.Characters.Enemies
{
    public class PandaEnemy : Enemy
    {
        public PandaEnemy(Rect area, Vector speed) : base(area, speed)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        public PandaEnemy(Rect area) : base(area)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        private readonly string name = "PandaEnemy";
        private readonly string description = "PandaEnemy";
        private readonly double health = 2;
        private readonly double currentHealth = 2;
        private readonly double power = 2;
    }
}
