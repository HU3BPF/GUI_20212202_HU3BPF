using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FarFromFreedom.Renderer
{
    internal static class BurshRenderer
    {
        private static Brush pigEnemyBursh = GetBrushes(Path.Combine("Images", "enemies", "level1", "pigEnemy.gif")); 
        private static Brush hippoEnemyBursh = GetBrushes(Path.Combine("Images", "enemies", "level1", "hippoEnemy.gif"));
        private static Brush pandaEnemyBursh = GetBrushes(Path.Combine("Images", "enemies", "level1", "pandaEnemy.gif"));
        private static Brush penguinEnemyBursh = GetBrushes(Path.Combine("Images", "enemies", "level1", "penguinEnemy.gif"));
        private static Brush walkingSnailEnemyBursh = GetBrushes(Path.Combine("Images", "enemies", "level2", "walkingSnailEnemy.gif"));
        private static Brush eatingCactusEnemyBursh = GetBrushes(Path.Combine("Images", "enemies", "level2", "eatingCactusEnemy.gif"));
        private static Brush clamFlowerEnemyBursh = GetBrushes(Path.Combine("Images", "enemies", "level2", "clamFlowerEnemy.gif"));
        private static Brush threeEyesEnemyBursh = GetBrushes(Path.Combine("Images", "enemies", "level2", "threeEyesEnemy.gif"));
        private static Brush furryEnemyBursh = GetBrushes(Path.Combine("Images", "enemies", "level2", "furryEnemy.gif"));
        private static Brush cutSwordEnemyBursh = GetBrushes(Path.Combine("Images", "enemies", "level2", "cutSwordEnemy.gif"));
        private static Brush batEnemyBursh = GetBrushes(Path.Combine("Images", "enemies", "level2", "batEnemy.gif"));
        private static Brush lemonEnemyBursh = GetBrushes(Path.Combine("Images", "enemies", "level2", "lemonEnemy.gif"));
        private static Brush flyingEnemyBursh = GetBrushes(Path.Combine("Images", "enemies", "level2", "flyingEnemy.gif"));
        private static Brush zombiGiphyEnemyBursh = GetBrushes(Path.Combine("Images", "enemies", "level3", "zombiGiphyEnemy.gif"));
        private static Brush zombieWalkCrippleEnemyBursh = GetBrushes(Path.Combine("Images", "enemies", "level3", "zombieWalkCrippleEnemy.gif"));
        private static Brush zombieRunBEnemyBursh = GetBrushes(Path.Combine("Images", "enemies", "level3", "zombieRunBEnemy.gif"));
        private static Brush zombieAttackBEnemyBursh = GetBrushes(Path.Combine("Images", "enemies", "level3", "zombieAttackBEnemy.gif"));
        private static Brush zombieAttackAEnemyBrush = GetBrushes(Path.Combine("Images", "enemies", "level3", "zombieAttackAEnemy.gif"));

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

            initGameDrawings.Add("PigEnemy", pigEnemyBursh);
            initGameDrawings.Add("HippoEnemy", hippoEnemyBursh);
            initGameDrawings.Add("PandaEnemy", pandaEnemyBursh);
            initGameDrawings.Add("PenguinEnemy", penguinEnemyBursh);
            initGameDrawings.Add("WalkingSnailEnemy", walkingSnailEnemyBursh);
            initGameDrawings.Add("EatingCactusEnemy", eatingCactusEnemyBursh);
            initGameDrawings.Add("ClamFlowerEnemy", clamFlowerEnemyBursh);
            initGameDrawings.Add("ThreeEyesEnemy", threeEyesEnemyBursh);
            initGameDrawings.Add("FurryEnemy", furryEnemyBursh);
            initGameDrawings.Add("CutSwordEnemy", cutSwordEnemyBursh);
            initGameDrawings.Add("BatEnemy", batEnemyBursh);
            initGameDrawings.Add("LemonEnemy", lemonEnemyBursh);
            initGameDrawings.Add("FlyingEnemyBursh", flyingEnemyBursh);
            initGameDrawings.Add("ZombiGiphyEnemy", zombiGiphyEnemyBursh);
            initGameDrawings.Add("ZombieWalkCrippleEnemy", zombieWalkCrippleEnemyBursh);
            initGameDrawings.Add("ZombieRunBEnemy", zombieRunBEnemyBursh);
            initGameDrawings.Add("ZombieAttackBEnemy", zombieAttackBEnemyBursh);
            initGameDrawings.Add("ZombieAttackAEnemy", zombieAttackAEnemyBrush);


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
            initGameDrawings.Add("TearsBrush", tearsBrush);
            initGameDrawings.Add("TimeBrush", timeBrush);

            return initGameDrawings;
        }
    }
}
