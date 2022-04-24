using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarFromFreedom.Model
{
    public class MenuModel : IMenuModel
    {
        private bool isWelcomePage = true;
        private bool canContiue;
        private readonly int _newGameWidth = 350;
        private readonly int _newGameHeight = 105;
        private double _newGameOpacity = 1;
        private readonly int _continueWidth = 350;
        private readonly int _continueHeight = 105;
        private double _continueOpacity = 0.5;
        private readonly int _optionsWidth = 350;
        private readonly int _optionsHeight = 105;
        private double _optionsOpacity = 0.8;
        private readonly int _statsWidth = 350;
        private readonly int _statsHeight = 105;
        private double _statsOpacity = 0.8;
        private readonly int _exitGameWidth = 350;
        private readonly int _exitGameHeight = 105;
        private double _exitGameOpacity = 0.8;
        private int selectedIndex = 0;



        public MenuModel()
        {
        }

        public bool IsWelcomePage
        {
            get { return isWelcomePage; }
            set { isWelcomePage = value; }
        }

        public int NewGameWidth => _newGameWidth;

        public int NewGameHeight => _newGameHeight;

        public double NewGameOpacity { get => _newGameOpacity; set => _newGameOpacity = value; }

        public int ContinueWidth => _continueWidth;

        public int ContinueHeight => _continueHeight;

        public double ContinueOpacity { get => _continueOpacity; set => _continueOpacity = value; }

        public int OptionsWidth => _optionsWidth;

        public int OptionsHeight => _optionsHeight;

        public double OptionsOpacity { get => _optionsOpacity; set => _optionsOpacity = value; }

        public int StatsWidth => _statsWidth;

        public int StatsHeight => _statsHeight;

        public double StatsOpacity { get => _statsOpacity; set => _statsOpacity = value; }

        public int ExitGameWidth => _exitGameWidth;

        public int ExitGameHeight => _exitGameHeight;

        public double ExitGameOpacity { get => _exitGameOpacity; set => _exitGameOpacity = value; }

        public int SelectedIndex { get => selectedIndex; set => selectedIndex = value; }

        public bool CanContiue { get => canContiue; set => canContiue = value; }

        public void ResetParams()
        {
            
            NewGameOpacity = 1;
            if (CanContiue)
            {
                ContinueOpacity = 0.8;
            }
            else
            {
                ContinueOpacity = 0.5;
            }           
            OptionsOpacity = 0.8;           
            StatsOpacity = 0.8;            
            ExitGameOpacity = 0.8;
            SelectedIndex = 0;
        }
    }
}
