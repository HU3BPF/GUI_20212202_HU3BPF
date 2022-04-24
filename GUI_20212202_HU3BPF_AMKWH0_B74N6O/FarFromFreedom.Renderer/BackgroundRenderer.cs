using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FarFromFreedom.Renderer
{
    internal static class BackgroundRenderer
    {
        private static Brush Leve1 = GetBrushes(Path.Combine("Images", "background", "Level1.jpg"));
        private static Brush Level1Start = GetBrushes(Path.Combine("Images", "background", "Level1_start.jpg"));
        private static Brush Level2 = GetBrushes(Path.Combine("Images", "background", "Level2.jpg"));
        private static Brush Level3 = GetBrushes(Path.Combine("Images", "background", "Level3.jpg"));

        private static ImageBrush GetBrushes(string file) => new ImageBrush(new BitmapImage(new Uri(file, UriKind.RelativeOrAbsolute)));
        internal static Dictionary<string, Brush> Init()
        {
            Dictionary<string, Brush> initGameDrawings = new Dictionary<string, Brush>();

            initGameDrawings.Add("Level1", Leve1);
            initGameDrawings.Add("Level1Start", Level1Start);
            initGameDrawings.Add("Level2", Level2);
            initGameDrawings.Add("Level3", Level3);

            return initGameDrawings;
        }
    }
}
