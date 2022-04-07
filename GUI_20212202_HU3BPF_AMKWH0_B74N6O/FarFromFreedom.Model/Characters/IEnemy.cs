﻿namespace FarFromFreedom.Model.Characters
{
    internal interface IEnemy
    {
        double CurrentHealth { get; }
        string Description { get; }
        double Health { get; }
        string Name { get; }
        double Power { get; }
        double Speed { get; }

        void CurrentHealthDown(double currentHealth);
        void CurrentHealthUp(double currentHealth);
        void HealthDown(double health);
        void HealthUp(double health);
        void PowerDown(double power);
        void PowerUp(double power);
        void SpeedDown(double speed);
        void SpeedUp(double speed);
    }
}