using System;
using System.IO;
using System.Windows;

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
            this.videoPlayer.Source = new Uri(Directory.GetCurrentDirectory() + "\\" + System.IO.Path.Combine("StoryVideo", "backgroundStory.mov"));
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
