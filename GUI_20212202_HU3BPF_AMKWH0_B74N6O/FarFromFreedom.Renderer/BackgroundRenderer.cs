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
        private static Brush Level1Start_base = GetBrushes(Path.Combine("Images", "levels", "Level1", "Level1_start.jpg"));
        private static Brush Level1_base = GetBrushes(Path.Combine("Images", "levels", "Level1", "Level1_base.jpg"));
        private static Brush Level1door_1 = GetBrushes(Path.Combine("Images", "levels", "Level1", "Level1door1_small.png"));
        private static Brush Level1door_2 = GetBrushes(Path.Combine("Images", "levels", "Level1", "Level1door2_small.png"));
        private static Brush Level1door_3 = GetBrushes(Path.Combine("Images", "levels", "Level1", "Level1door3_small.png"));
        private static Brush Level1door_4 = GetBrushes(Path.Combine("Images", "levels", "Level1", "Level1door4_small.png"));
        
        private static Brush Level2 = GetBrushes(Path.Combine("Images", "background", "Level2.jpg"));
        private static Brush Level3 = GetBrushes(Path.Combine("Images", "background", "Level3.jpg"));

        private static ImageBrush GetBrushes(string file) => new ImageBrush(new BitmapImage(new Uri(file, UriKind.RelativeOrAbsolute)));
        internal static Dictionary<string, Brush> Init()
        {
            Dictionary<string, Brush> initGameDrawings = new Dictionary<string, Brush>();

            initGameDrawings.Add("Level1Start_base", Level1Start_base);
            initGameDrawings.Add("Level1_base",Level1_base);
            initGameDrawings.Add("Level1door1",Level1door_1);
            initGameDrawings.Add("Level1door2",Level1door_2);
            initGameDrawings.Add("Level1door3",Level1door_3);
            initGameDrawings.Add("Level1door4",Level1door_4);


            //initGameDrawings.Add("Level1", Leve1);
            //initGameDrawings.Add("Level1Start", Level1Start);
            //initGameDrawings.Add("Level2", Level2);
            //initGameDrawings.Add("Level3", Level3);

            return initGameDrawings;
        }
    }
}
