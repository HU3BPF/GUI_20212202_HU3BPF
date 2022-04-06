using FarFromFreedom.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarFromFreedom.Model
{
    public interface IGameModel
    {
        MainCharacter Character { get; }
        List<Enemy> Enemies { get; set; }
        List<Item> Items { get; set; }
        SavedGame SavedGame { get; set; }
    }
}
