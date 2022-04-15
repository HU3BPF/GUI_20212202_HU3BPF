
using System.Windows;

namespace FarFromFreedom.Model.Characters.Enemies
{
    public class ThreeEyesEnemy : Enemy
    {
        public ThreeEyesEnemy(Rect area, Vector speed) : base(area, speed)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        public ThreeEyesEnemy(Rect area) : base(area)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        private readonly string name = "ThreeEyesEnemy";
        private readonly string description = "ThreeEyesEnemy";
        private readonly double health = 2;
        private readonly double currentHealth = 2;
        private readonly double power = 2;
    }
}
