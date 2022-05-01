using FarFromFreedom.Model.Characters;
using System.Collections.Generic;

namespace FarFromFreedom.Model
{
    public interface IGameModel : IModel
    {
        IMainCharacter Character { get; set; }
        List<IEnemy> Enemies { get; set; }
        List<IItem> Items { get; set; }
        List<Bullet> Bullets { get; set; }

        int UpperNeighbour { get; set; }
        int LowerNeighbour { get; set; } 
        int RightNeighbour { get; set; } 
        int LeftNeighbour { get; set; } 

        void Init(List<IEnemy> enemies, List<IItem> Items);
    }
}