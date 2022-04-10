using System.Windows;

namespace FarFromFreedom.Model.Characters
{
    public interface IMainCharacter
    {
        double CurrentHealth { get; }
        string Description { get; }
        double Health { get; }
        string Name { get; }
        double Power { get; }
        Vector Speed { get; }
        int Coin { get; }

        void CurrentHealthUp(double currentHealth);
        void CurrentHealthDown(double currentHealth);
        void HealthUp(double health);
        void HealthDown(double health);
        void PowerUp(double power);
        void PowerDown(double power);
        void SpeedUp(Vector speed);
        void SpeedDown(Vector speed);
        void CoinUp(int coin);
        void CoinDown(int coin);
    }
}