using FarFromFreedom.Model.Characters;
using System.Collections.Generic;

namespace FarFromFreedom.Model
{
    public class GameModel : IGameModel
    {
        public GameModel(MainCharacter character) => Character = character;

        public MainCharacter Character {get;}

        public List<Enemy> Enemies { get; set; }
        public List<IItem> Items { get; set; }

        public void Init(List<Enemy> enemies, List<IItem> Items)
        {
            this.Enemies = enemies;
            this.Items = Items;
        }
    }
}
