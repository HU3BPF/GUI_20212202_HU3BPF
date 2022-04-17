using Newtonsoft.Json;
using System.Windows;

namespace FarFromFreedom.Model.Characters.Enemies
{
    public class CutSwordEnemy : Enemy
    {
        [JsonConstructor]
        public CutSwordEnemy(string Name,string Description,double Health, double Power, double CurrentHealth, string Area, string Speed) : base(Area, Speed)
        {
            this.initProperty(Name, Description, Health, CurrentHealth, Power);
        }
        public CutSwordEnemy()
        {

        }
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
