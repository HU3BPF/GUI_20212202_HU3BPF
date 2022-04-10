using FarFromFreedom.Model;
using FarFromFreedom.Model.Characters;
using FarFromFreedom.Model.Items;
using FarFromFreedom.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            GameModel game = new GameModel(new MainCharacter("Dobby","alma",5.5,5.5,3,new Vector(1,2),12,new Rect(50,50,50,50)));
            List<Enemy> enemies = new List<Enemy>();
            List< IItem > Items = new List<IItem>();
            Items.Add(new Coin("coin", "alma", 1));
            Items.Add(new Coin("coin3", "alma", 1));
            Items.Add(new Coin("coin2", "alma", 1));
            enemies.Add(new Enemy("Hippo", "fat", 10, 10, 5, new Vector(1, 1), new Rect(400, 200, 300, 220)));
            enemies.Add(new Enemy("pig", "fat", 10, 10, 5, new Vector(1, 1), new Rect(60, 50, 200, 200)));
            enemies.Add(new Enemy("pig", "fat", 10, 10, 5, new Vector(1, 1), new Rect(100, 300, 400, 200)));
            game.Init(enemies,Items);
            gameControl = new GameControl(game);
            this.Content = gameControl;


            MainMenu page=new MainMenu();
            page.Show();
        }
    }
}
