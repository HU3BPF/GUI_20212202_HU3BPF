using FarFromFreedom.Model;
using FarFromFreedom.Model.Characters;
using FarFromFreedom.Model.Characters.Enemies;
using FarFromFreedom.Model.Items;
using FarFromFreedom.Pages;
using System.Collections.Generic;
using System.Windows;

namespace FarFromFreedom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameControl gameControl;
        public MainWindow()
        {
            InitializeComponent();
            GameModel game = new GameModel(new MainCharacter("Dobby", "alma", 100, 100, 3, 12, new Rect(500, 500, 100, 100)));
            List<Enemy> enemies = new List<Enemy>();
            List<IItem> Items = new List<IItem>();
            Items.Add(new Coin(new Rect(200, 200, 100, 100)));
            Items.Add(new Coin(new Rect(200, 300, 300, 220)));
            Items.Add(new Coin(new Rect(400, 400, 300, 220)));
            enemies.Add(new CatEnemy(new Rect(500, 100, 300, 220), new Vector(1, 1)));
            enemies.Add(new MonsterEnemy(new Rect(200, 300, 300, 220), new Vector(1, 1)));
            enemies.Add(new MushroomEnemy(new Rect(200, 500, 300, 220), new Vector(1, 1)));
            enemies.Add(new WaspEnemy(new Rect(200, 300, 100, 100), new Vector(1, 1)));
            enemies.Add(new ZombieWalkCrippleEnemy(new Rect(400, 200, 100, 100), new Vector(1, 1)));
            game.Init(enemies, Items);
            gameControl = new GameControl(game);
            this.Content = gameControl;


            MainMenu page = new MainMenu(gameControl);
           page.Show();
        }
    }
}
