using FarFromFreedom.Model.Items;
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
        int Coin { get; }
        bool CharacterMoved { get; set; }
        DirectionAnimationHelper DirectionHelper { get; }
        void CurrentHealthUp(double currentHealth);
        void CurrentHealthDown(double currentHealth);
        void HealthUp(double health);
        void HealthDown(double health);
        void PowerUp(double power);
        void PowerDown(double power);
        void CoinUp(int coin);
        void CoinDown(int coin);
    }
}