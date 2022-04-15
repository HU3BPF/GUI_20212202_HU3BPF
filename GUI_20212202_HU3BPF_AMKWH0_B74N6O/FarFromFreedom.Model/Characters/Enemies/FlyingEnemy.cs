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

        private string name;
        private string description;
        private double health;
        private double currentHealth;
        private double power;
    }
}
