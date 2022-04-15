
using System.Windows;

namespace FarFromFreedom.Model.Characters.Enemies
{
    public class ZombiGiphyEnemy : Enemy
    {
        public ZombiGiphyEnemy(Rect area, Vector speed) : base(area, speed)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        public ZombiGiphyEnemy(Rect area) : base(area)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        private readonly string name = "ZombiGiphyEnemy";
        private readonly string description = "ZombiGiphyEnemy";
        private readonly double health = 2;
        private readonly double currentHealth = 2;
        private readonly double power = 2;
    }
}
