using FarFromFreedom.Model.Characters;
using FarFromFreedom.Model.Items;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows;

namespace FarFromFreedom.Model
{
    public class GameModel : IGameModel
    {
        public GameModel(MainCharacter character) => Character = character;

        [JsonConstructor]
        public GameModel(MainCharacter character, List<Enemy> enemies, List<IItem> items, List<Bullet> bullets)
        {
            Character = character;
            Enemies = enemies;
            Items = items;
            bullets = bullets;

        }
        public GameModel()
        {

        }

        public MainCharacter Character { get; } = new MainCharacter("Dobby", "alma", 5.5, 5.5, 3, 12, new Rect(50, 50, 50, 50));

        public List<Enemy> Enemies { get; set; } = new List<Enemy>();
        public List<IItem> Items { get; set; } = new List<IItem>();

        public List<Bullet> bullets { get; set; } = new List<Bullet>();

        public void Init(List<Enemy> enemies, List<IItem> Items)
        {
            this.Enemies = enemies;
            this.Items = Items;
        }
    }
}
