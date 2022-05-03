using FarFromFreedom.Logic;
using FarFromFreedom.Model;
using FarFromFreedom.Model.Characters;
using FarFromFreedom.Model.Characters.Enemies;
using FarFromFreedom.Model.Items;
using FarFromFreedom.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FarFromFreedom
{
    public class MenuSubControl
    {
        IMenuLogic? logic;

        public void Init(IMenuModel model)
        {
            logic = new MenuLogic(model);
            
        }

        public void Dispose()
        {
            logic = null;
        }

        public int HandleInput(BaseControl control, IMenuModel menuModel, object sender, KeyEventArgs e)
        {
            if (e != null)
            {
                switch (e.Key)
                {

                    case Key.Enter:
                        this.HandleSelection(control, logic?.SelectIndex());
                        return 1;
                    case Key.Escape:
                        menuModel.IsWelcomePage = true;
                        return 1;
                    case Key.Up:
                        logic?.DescSelectedIndex();
                        return 1;
                    case Key.Down:
                        logic?.IncSelectedIndex();
                        return 1;
                    case Key.S:
                        logic?.IncSelectedIndex();
                        return 1;
                    case Key.W:
                        logic?.DescSelectedIndex();
                        return 1;
                    case Key.Space:
                        this.HandleSelection(control, logic?.SelectIndex());
                        return 1;
                    case Key.Back:
                        menuModel.IsWelcomePage = true;
                        return 1;
                }
            }
            return -1;
        }

        private void HandleSelection(BaseControl control, IModel model)
        {
            if (model == null)
            {
                Window.GetWindow(control).Close();
                return;
            }

            if (model is IGameModel gameModel)
            {
                if (gameModel.Level == 1 && gameModel.RoomID == 1 && gameModel.Character.Highscore == 0)
                {
                    Intro introWindow = new Intro();
                    introWindow.ShowDialog();
                }
                control.ChangeModel(gameModel);
            }
            
            
        }

        private void NewGame(BaseControl control)
        {
            IFarFromFreedomRepository repo = FarFromFreedomRepository.Instance();
            IGameModel game = repo.GameModelMap[0][1];
            Intro introWindow = new Intro();
            introWindow.ShowDialog();
            game.Character = new MainCharacter("Dobby", "alma", 100, 100, 3, 12, new Rect(400, 200, 100, 100));

            control.ChangeModel(game);
        }

        private void GameLoad(BaseControl control)
        {
            IFarFromFreedomRepository repo = FarFromFreedomRepository.Instance();
            IGameModel game = repo.GameModelMap[0][1];
            game.Character = new MainCharacter("Dobby", "alma", 100, 100, 3, 12, new Rect(400, 200, 100, 100));
            
            control.ChangeModel(game);

        }

        
    }
}
