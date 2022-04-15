﻿using System.Windows;

namespace FarFromFreedom.Model.Characters.Enemies
{
    public class PigEnemy : Enemy
    {
        public PigEnemy(Rect area, Vector speed) : base(area, speed)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        public PigEnemy(Rect area) : base(area)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        private readonly string name = "PigEnemy";
        private readonly string description = "description";
        private readonly double health = 2;
        private readonly double currentHealth = 2;
        private readonly double power = 2;
    }
}