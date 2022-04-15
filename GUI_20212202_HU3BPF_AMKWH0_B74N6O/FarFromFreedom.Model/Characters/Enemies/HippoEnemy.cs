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

        private string name = "HippoEnemy";
        private string description = "FAT";
        private double health = 2;
        private double currentHealth = 2;
        private double power = 2;
    }
}
