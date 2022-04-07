﻿namespace FarFromFreedom.Model.Characters
{
    public class MainCharacter : IMainCharacter
    {
        public MainCharacter(string name, string description, double health, double currentHealth, double power, double speed, int coin)
        {
            this.name = name;
            this.description = description;
            this.health = health;
            this.currentHealth = currentHealth;
            this.power = power;
            this.speed = speed;
            this.coin = coin;
        }

        private string name;
        private string description;
        private double health;
        private double currentHealth;
        private double power;
        private double speed;
        private int coin;

        public string Name => name;

        public string Description => description;

        public double Health => health;

        public double Power => power;

        public double Speed => speed;

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

        public void SpeedUp(double speed)
        {
            this.speed += speed;
        }

        public void SpeedDown(double speed)
        {
            this.speed -= speed;
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