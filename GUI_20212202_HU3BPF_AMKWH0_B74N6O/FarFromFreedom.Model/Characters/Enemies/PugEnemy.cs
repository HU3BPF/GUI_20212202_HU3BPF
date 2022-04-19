﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace FarFromFreedom.Model.Characters.Enemies
{
    public class PugEnemy : Enemy
    {
        [JsonConstructor]
        public PugEnemy(string name, string description, double health, double power, double currentHealth, Rect area, Vector speed) : base(area, speed)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }
        public PugEnemy()
        {

        }
        public PugEnemy(Rect area, Vector speed) : base(area, speed)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        public PugEnemy(Rect area) : base(area)
        {
            this.initProperty(name, description, health, currentHealth, power);
        }

        private readonly string name = "pugEnemy";
        private readonly string description = "PugEnemy";
        private readonly double health = 2;
        private readonly double currentHealth = 2;
        private readonly double power = 2;

        public override int level => 1;
    }
}
