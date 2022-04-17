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
            GameModel game = new GameModel(new MainCharacter("Dobby", "alma", 100, 100, 3, 12, new Rect(50, 50, 300, 350)));
            List<Enemy> enemies = new List<Enemy>();
            List<IItem> Items = new List<IItem>();
            Items.Add(new Coin(new Rect(0, 0, 0, 0)));
            Items.Add(new Coin(new Rect(200, 30, 300, 220)));
            Items.Add(new Coin(new Rect(400, 400, 300, 220)));
            enemies.Add(new HippoEnemy(new Rect(600, 10, 300, 220), new Vector(1, 1)));
            enemies.Add(new PigEnemy(new Rect(200, 300, 300, 220), new Vector(1, 1)));
            enemies.Add(new CutSwordEnemy(new Rect(100, 500, 300, 220), new Vector(1, 1)));
            game.Init(enemies, Items);
            gameControl = new GameControl(game);
            this.Content = gameControl;


            MainMenu page = new MainMenu(gameControl);
           page.Show();
        }
    }
}
