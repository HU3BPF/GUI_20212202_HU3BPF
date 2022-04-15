using System.Windows;

namespace FarFromFreedom.Model.Characters.Enemies
{
    public class HippoEnemy : Enemy
    {
        public HippoEnemy(Rect area, Vector speed) : base(area, speed)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        public HippoEnemy(Rect area) : base(area)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        private readonly string name = "HippoEnemy";
        private readonly string description = "FAT";
        private readonly double health = 2;
        private readonly double currentHealth = 2;
        private readonly double power = 2;
    }
}
