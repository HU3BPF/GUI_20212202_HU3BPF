using System.Windows;
using System.Windows.Media;

namespace FarFromFreedom.Model.Characters
{
    public class MainCharacter : GameItem, IMainCharacter
    {
        public MainCharacter(string name, string description, double health, double currentHealth, double power, Vector speed, int coin, Rect area) : base(area, speed)
        {
            this.name = name;
            this.description = description;
            this.health = health;
            this.currentHealth = currentHealth;
            this.power = power;
            this.coin = coin;
        }

        private string name;
        private string description;
        private double health;
        private double currentHealth;
        private double power;
        private int coin;

        public string Name => name;

        public string Description => description;

        public double Health => health;

        public double Power => power;

        public double CurrentHealth => currentHealth;

        public int Coin => coin;


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

        public void CoinUp(int coin)
        {
            this.coin += coin;
        }

        public void CoinDown(int coin)
        {
            this.coin -= coin;
        }
    }
}
