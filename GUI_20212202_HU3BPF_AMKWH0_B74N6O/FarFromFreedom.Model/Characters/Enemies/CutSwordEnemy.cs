using System.Windows;

namespace FarFromFreedom.Model.Characters.Enemies
{
    public class CutSwordEnemy : Enemy
    {
        public CutSwordEnemy(Rect area, Vector speed) : base(area, speed)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        public CutSwordEnemy(Rect area) : base(area)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        private readonly string name = "CutSwordEnemy";
        private readonly string description = "description";
        private readonly double health = 2;
        private readonly double currentHealth = 2;
        private readonly double power = 2;
    }
}
