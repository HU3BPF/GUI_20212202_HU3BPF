using System.Windows;

namespace FarFromFreedom.Model.Characters.Enemies
{
    public class EatingCactusEnemy : Enemy
    {
        public EatingCactusEnemy(Rect area, Vector speed) : base(area, speed)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        public EatingCactusEnemy(Rect area) : base(area)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        private readonly string name = "EatingCactusEnemy";
        private readonly string description = "EatingCactusEnemy";
        private readonly double health = 2;
        private readonly double currentHealth = 2;
        private readonly double power = 2;
    }
}
