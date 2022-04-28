using FarFromFreedom.Model.Characters;
using FarFromFreedom.Model.Items;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows;

namespace FarFromFreedom.Model
{
    public class GameModel : IGameModel
    {
        private IMainCharacter character;
        private List<IEnemy> enemies;
        private List<IItem> items;
        private List<Bullet> bullets;

        
        public GameModel(MainCharacter character) => Character = character;

        //[JsonConstructor]
        //public GameModel(MainCharacter character, List<Enemy> enemies, List<IItem> items, List<Bullet> bullets)
        //{
        //    Character = character;
        //    Enemies = enemies;
        //    Items = items;
        //    bullets = bullets;

        //}
        [JsonConstructor]
        public GameModel(List<IEnemy> enemies, List<IItem> items)
        {
            this.enemies = enemies;
            this.items = items;
            this.bullets = new List<Bullet>();
        }
        public GameModel()
        {
            this.enemies = new List<IEnemy>();
            this.items = new List<IItem>();
            this.bullets = new List<Bullet>();
        }

        public IMainCharacter Character { get => this.character; set => this.character = value; }

        public List<IEnemy> Enemies { get => this.enemies; set => this.enemies = value; }
        public List<IItem> Items { get => this.items; set => this.items = value; }

        public List<Bullet> Bullets { get => this.bullets; set => this.bullets = value; }

        public void Init(List<IEnemy> enemies, List<IItem> items)
        {
            this.enemies = enemies;
            this.items = items;
            this.bullets = new List<Bullet>(); ;
        }
    }
}
