using FarFromFreedom.Model.Characters;
using System.Collections.Generic;

namespace FarFromFreedom.Model
{
    public interface IGameModel : IModel
    {
        IMainCharacter Character { get; }
        List<IEnemy> Enemies { get; set; }
        List<IItem> Items { get; set; }
        List<Bullet> Bullets { get; set; }

        void Init(List<IEnemy> enemies, List<IItem> Items);
    }
}