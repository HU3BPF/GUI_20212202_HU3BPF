using FarFromFreedom.Model.Characters;
using System.Collections.Generic;

namespace FarFromFreedom.Model
{
    public interface IGameModel : IModel
    {
        MainCharacter Character { get; }
        List<Enemy> Enemies { get; set; }
        List<IItem> Items { get; set; }
        List<Bullet> bullets { get; set; }

        void Init(List<Enemy> enemies, List<IItem> Items);
    }
}