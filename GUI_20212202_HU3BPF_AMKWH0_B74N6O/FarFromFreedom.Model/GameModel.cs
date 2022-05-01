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
        private int upperNeighbour;
        private int lowerNeighbour;
        private int rightNeighbour;
        private int leftNeighbour;



        public GameModel(MainCharacter character) => Character = character;

        //[JsonConstructor]
        //public GameModel(MainCharacter character, List<Enemy> enemies, List<IItem> items, List<Bullet> bullets)
        //{
        //    Character = character;
        //    Enemies = enemies;
        //    Items = items;
        //    bullets = bullets;

        //}

        public GameModel(int[] neighbours, List<IEnemy> enemies, List<IItem> items)
        {
            this.upperNeighbour = neighbours[0];
            this.rightNeighbour = neighbours[1];
            this.lowerNeighbour = neighbours[2];
            this.leftNeighbour = neighbours[3];

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
        public int UpperNeighbour { get => this.upperNeighbour; set => this.upperNeighbour = value; }
        public int LowerNeighbour { get => this.lowerNeighbour; set => this.lowerNeighbour = value; }
        public int RightNeighbour { get => this.rightNeighbour; set => this.rightNeighbour = value; }
        public int LeftNeighbour { get => this.leftNeighbour; set => this.leftNeighbour = value; }

        public void Init(List<IEnemy> enemies, List<IItem> items)
        {
            this.enemies = enemies;
            this.items = items;
            this.bullets = new List<Bullet>(); ;
        }
    }
}
