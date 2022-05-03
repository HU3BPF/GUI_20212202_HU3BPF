using FarFromFreedom.Model;
using FarFromFreedom.Model.Characters;
using FarFromFreedom.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FarFromFreedom.Logic
{
    public class MenuLogic : IMenuLogic
    {
        IMenuModel model;

        public MenuLogic(IMenuModel model)
        {
            this.model = model;
            this.CheckForSave();
        }

        /// <summary>
        /// Megnézi, hogy van e betölthető mentés. Ha van az egy boolban eltárolódik majd. 
        /// </summary>
        private void CheckForSave()
        {
            //Itt kellene megoldani azt, hogy ha van folytatható játék akkor 
            if (true)
            {
                this.model.CanContiue = true;
                this.model.ContinueOpacity = 0.8;
            }
        }


        public void DescSelectedIndex()
        {
            if (this.model.SelectedIndex > 0)
            {
                this.SetIndexesOpacity(this.model.SelectedIndex, 0.8);

                if (this.model.SelectedIndex-1 == 1 && !this.model.CanContiue)
                {
                    this.model.SelectedIndex -= 2;
                }
                else
                {
                    this.model.SelectedIndex--;
                }
                this.SetIndexesOpacity(this.model.SelectedIndex, 1);

            }
        }


        public void IncSelectedIndex()
        {

            if (this.model.SelectedIndex < 3)
            {
                this.SetIndexesOpacity(this.model.SelectedIndex, 0.8);
                if (this.model.SelectedIndex + 1 == 1 && !this.model.CanContiue)
                {
                    this.model.SelectedIndex += 2;
                }
                else
                {
                    this.model.SelectedIndex++;
                }
                this.SetIndexesOpacity(this.model.SelectedIndex, 1);
            }
        }

        /// <summary>
        /// Beállítja a megfelelő indexű menüelem átlátszatlanságát.
        /// </summary>
        /// <param name="index"> A menüelem indexe. </param>
        /// <param name="opacity"> A kívánt átlátszatlanság. </param>
        private void SetIndexesOpacity(int index, double opacity)
        {
            switch (index)
            {
                case 0: this.model.NewGameOpacity = opacity; break;
                case 1: this.model.ContinueOpacity = opacity; break;
                case 2: this.model.StatsOpacity = opacity; break;
                case 3: this.model.ExitGameOpacity = opacity; break;
            }
        }

        /// <summary>
        /// Ezzel a metódussal érjük el, hogy kiválaszt egy menüelemet a felhasználó.
        /// Ennek a hatására egy új modelnek kell majd betöltődni a BaseControl osztályba 
        /// </summary>
        /// <param name="selectedIndex"></param>
        public IModel SelectIndex()
        {
            switch (this.model.SelectedIndex)
            {
                case 0:
                    IFarFromFreedomRepository repo = FarFromFreedomRepository.Instance();
                    IGameModel game = repo.GameModelMap[0][1];
                    game.Character = new MainCharacter("Dobby", "alma", 100, 100, 3, 12, new Rect(604, 312, 70, 100));
                    return game;
                case 3:
                    return null;
                default:
                    break;
            }
            return new MenuModel();
        }
    }
}
