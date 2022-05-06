using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarFromFreedom.Model
{
    public class PauseModel
    {
        private int selectedIndex = 0;
        private double continueOpacity = 1;
        private double saveOpacity = 0.7;

        private bool isDead;

        public int SelectedIndex { get => selectedIndex; set => selectedIndex = value; }
        public double ContinueOpacity { get => continueOpacity; set => continueOpacity = value; }
        public double SaveOpacity { get => saveOpacity; set => saveOpacity = value; }
        public bool IsDead { get => isDead; set => isDead = value; }
    }
}
