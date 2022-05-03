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
        BaseControl control;

        public MainWindow()
        {
            InitializeComponent();

        }
    }
}
