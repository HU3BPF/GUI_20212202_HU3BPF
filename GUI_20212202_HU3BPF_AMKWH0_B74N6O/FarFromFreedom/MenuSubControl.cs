using FarFromFreedom.Logic;
using FarFromFreedom.Model;
using FarFromFreedom.Model.Characters;
using FarFromFreedom.Model.Characters.Enemies;
using FarFromFreedom.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FarFromFreedom
{
    static class MenuSubControl
    {
        static MenuLogic logic;

        public static void Init(IMenuModel model)
        {
            logic = new MenuLogic(model);
            
        }

        public static int HandleInput(BaseControl control, IMenuModel menuModel, object sender, KeyEventArgs e)
        {
            if (e != null)
            {
                switch (e.Key)
                {

                    case Key.Enter:
                        logic.SelectIndex(menuModel.SelectedIndex);
                        if (menuModel.SelectedIndex < 2)
                        {
                            ChangeModel(control);
                        }
                        return 1;
                    case Key.Escape:
                        menuModel.IsWelcomePage = true;
                        return 1;
                    case Key.Up:
                        logic.DescSelectedIndex();
                        return 1;
                    case Key.Down:
                        logic.IncSelectedIndex();
                        return 1;
                    case Key.S:
                        logic.IncSelectedIndex();
                        return 1;
                    case Key.W:
                        logic.DescSelectedIndex();
                        return 1;
                    case Key.Space:
                        logic.SelectIndex(menuModel.SelectedIndex);
                        if (menuModel.SelectedIndex < 2)
                        {
                            ChangeModel(control);
                        }
                        return 1;
                    case Key.Back:
                        menuModel.IsWelcomePage = true;
                        return 1;
                }
            }
            return -1;
        }

        private static void ChangeModel(BaseControl control)
        {
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

            control.ChangeModel(game);

        }

        internal static void Dispose()
        {
            logic = null;
        }
    }
}
