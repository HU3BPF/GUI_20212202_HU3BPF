using System.Windows;
using System.Windows.Media;

namespace FarFromFreedom.Model.Characters
{
    public abstract class Enemy : GameItem, IEnemy
    {
        public Enemy(Rect area, Vector speed) : base(area, speed)
        {
            this.name = name;
            this.description = description;
            this.health = health;
            this.currentHealth = currentHealth;
            this.power = power;
        }

        public Enemy(Rect area) : base(area)
        {
            this.name = name;
            this.description = description;
            this.health = health;
            this.currentHealth = currentHealth;
            this.power = power;
        }

        private protected void initProperty(string name, string description, double health, double currentHealth, double power)
        {
            this.name = name;
            this.description = description;
            this.health = health;
            this.currentHealth = currentHealth;
            this.power = power;
        }

        private string name;
        private string description;
        private double health;
        private double currentHealth;
        private double power;

        public string Name => name;

        public string Description => description;

        public double Health => health;

        public double Power => power;

        public double CurrentHealth => currentHealth;

        public void PowerUp(double power)
        {
            this.power += power;
        }

        public void PowerDown(double power)
        {
            this.power -= power;
        }

        public void HealthUp(double health)
        {
            this.health += health;
        }

        public void HealthDown(double health)
        {
            this.health -= health;
        }

        public void CurrentHealthUp(double currentHealth)
        {
            this.currentHealth += currentHealth;
        }

        public void CurrentHealthDown(double currentHealth)
        {
            this.currentHealth -= currentHealth;
        }
    }
}
