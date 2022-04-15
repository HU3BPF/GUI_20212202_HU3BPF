using System.Windows;

namespace FarFromFreedom.Model.Characters.Enemies
{
    public class FurryEnemy : Enemy
    {
        public FurryEnemy(Rect area, Vector speed) : base(area, speed)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        public FurryEnemy(Rect area) : base(area)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        private readonly  string name = "FurryEnemy";
        private readonly string description = "FurryEnemy";
        private readonly double health = 2;
        private readonly double currentHealth = 2;
        private readonly double power = 2;
    }
}
