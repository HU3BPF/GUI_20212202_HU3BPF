﻿using System.Windows;

namespace FarFromFreedom.Model.Characters.Enemies
{
    public class ZombieWalkCrippleEnemy : Enemy
    {
        public ZombieWalkCrippleEnemy(Rect area, Vector speed) : base(area, speed)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        public ZombieWalkCrippleEnemy(Rect area) : base(area)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        private readonly string name = "ZombieWalkCrippleEnemy";
        private readonly string description = "ZombieWalkCrippleEnemy";
        private readonly double health = 2;
        private readonly double currentHealth = 2;
        private readonly double power = 2;
    }
}
