using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Intro.xaml
    /// </summary>
    public partial class Intro : Window
    {
        public Intro()
        {
            InitializeComponent();
            this.videoPlayer.Source = new Uri(Directory.GetCurrentDirectory() +"\\"+ System.IO.Path.Combine("StoryVideo", "backgroundStory.mov"));
            //this.videoPlayer.Source = new Uri(System.IO.Path.Combine("StoryVideo", "backgroundStory.mov"));
            //this.videoPlayer.Source = System.IO.Path.Combine("StoryVideo", "backgroundStory.mov
            this.videoPlayer.MediaEnded += CloseWindow;
            this.KeyDown += CloseWindow;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
