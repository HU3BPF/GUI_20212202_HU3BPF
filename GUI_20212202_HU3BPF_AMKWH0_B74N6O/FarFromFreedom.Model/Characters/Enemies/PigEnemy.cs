using System.Windows;

namespace FarFromFreedom.Model.Characters.Enemies
{
    public class PigEnemy : Enemy
    {
        public PigEnemy(Rect area, Vector speed) : base(area, speed)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        public PigEnemy(Rect area) : base(area)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        private string name = "PigEnemy";
        private string description = "description";
        private double health = 2;
        private double currentHealth = 2;
        private double power = 2;
    }
}
