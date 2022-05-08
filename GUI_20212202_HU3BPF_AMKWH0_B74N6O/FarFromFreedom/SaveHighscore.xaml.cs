using FarFromFreedom.Logic;
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
using System.Windows.Shapes;

namespace FarFromFreedom
{
    /// <summary>
    /// Interaction logic for SaveHighscore.xaml
    /// </summary>
    public partial class SaveHighscore : Window
    {
        IGameLogic logic;
        public SaveHighscore(IGameLogic logic)
        {
            this.logic = logic;
            InitializeComponent();
            if (this.logic.Won)
            {
                this.label.Content = "Congratulations, You won!";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.logic.SaveHighscore(this.tbox.Text);
            this.Close();
        }
    }
}
