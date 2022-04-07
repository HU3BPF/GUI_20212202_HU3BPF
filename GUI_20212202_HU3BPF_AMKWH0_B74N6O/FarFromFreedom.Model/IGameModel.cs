using FarFromFreedom.Model.Characters;
using System.Collections.Generic;

namespace FarFromFreedom.Model
{
    public interface IGameModel
    {
        MainCharacter Character { get; }
        List<Enemy> Enemies { get; set; }
        List<IItem> Items { get; set; }
        SavedGame SavedGame { get; set; }
    }
}
