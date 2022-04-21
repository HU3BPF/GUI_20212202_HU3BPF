using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FarFromFreedom.Renderer
{
    internal static class BurshRenderer
    {
        //Items
        private static  Brush bagBrush = GetBrushes(Path.Combine("Images", "items", "bag.png"));
        private static Brush bombBrush = GetBrushes(Path.Combine("Images", "items", "bomb.png"));
        private static Brush bottle2Brush = GetBrushes(Path.Combine("Images", "items", "bottle2.png"));
        private static Brush coinBrush = GetBrushes(Path.Combine("Images", "items", "coin.png"));
        private static Brush heartBrush = GetBrushes(Path.Combine("Images", "items", "heart.png"));
        private static Brush heart2Brush = GetBrushes(Path.Combine("Images", "items", "heart2.png"));
        private static Brush moneyBrush = GetBrushes(Path.Combine("Images", "items", "money.png"));
        private static Brush shieldBrush = GetBrushes(Path.Combine("Images", "items", "shield.png"));
        private static Brush starBrush = GetBrushes(Path.Combine("Images", "items", "star.png"));
        private static Brush tearsBrush = GetBrushes(Path.Combine("Images", "items", "tears.png"));
        private static Brush timeBrush = GetBrushes(Path.Combine("Images", "items", "time.png"));

        private static ImageBrush GetBrushes(string file) => new ImageBrush(new BitmapImage(new Uri(file, UriKind.RelativeOrAbsolute)));
        internal static Dictionary<string, Brush> Init()
        {
            Dictionary<string, Brush> initGameDrawings = new Dictionary<string, Brush>();

            initGameDrawings.Add("TearsBrush", tearsBrush);

            //Items
            initGameDrawings.Add("Bag", bagBrush);
            initGameDrawings.Add("Bomb", bombBrush);
            initGameDrawings.Add("Bottle2", bottle2Brush);
            initGameDrawings.Add("Heart2", heart2Brush);
            initGameDrawings.Add("Coin", coinBrush);
            initGameDrawings.Add("Heart", heartBrush);
            initGameDrawings.Add("Money", moneyBrush);
            initGameDrawings.Add("Star", starBrush);
            initGameDrawings.Add("Shield", shieldBrush);
            initGameDrawings.Add("TimeBrush", timeBrush);

            return initGameDrawings;
        }
    }
}
