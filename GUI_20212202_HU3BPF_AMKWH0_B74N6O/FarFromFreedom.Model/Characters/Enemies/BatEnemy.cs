﻿using System.Windows;

namespace FarFromFreedom.Model.Characters.Enemies
{
    public class BatEnemy : Enemy
    {
        public BatEnemy(Rect area, Vector speed) : base(area, speed)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        public BatEnemy(Rect area) : base(area)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        private readonly string name = "BatEnemy";
        private readonly string description = "BatEnemy";
        private readonly double health = 2;
        private readonly double currentHealth = 2;
        private readonly double power = 2;
    }
}