using FarFromFreedom.Model;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System;
using System.Windows.Media.Animation;
using System.Collections.Generic;

namespace FarFromFreedom.Renderer
{
    public class GameRenderer : FrameworkElement
    {
        private Dictionary<String, Drawing> GameDrawings;
        private IGameModel model;
        public GameRenderer(IGameModel model)
        {
            this.model = model;
        }

        public Dictionary<String, Drawing> BuildDrawing()
        {
            GameDrawings = Init();
            

            return GameDrawings;
        }
        private Brush pigEnemyBursh { get => GetBrushes(Path.Combine("Images", "enemies", "level1", "pigEnemy.gif")); }
        private Brush hippoEnemyBursh { get => GetBrushes(Path.Combine("Images", "enemies", "level1", "hippoEnemy.gif")); }
        private Brush pandaEnemyBursh { get => GetBrushes(Path.Combine("Images", "enemies", "level1", "pandaEnemy.gif")); }
        private Brush penguinEnemyBursh { get => GetBrushes(Path.Combine("Images", "enemies", "level1", "penguinEnemy.gif")); }
        private Brush walkingSnailEnemyBursh { get => GetBrushes(Path.Combine("Images", "enemies", "level2", "walkingSnailEnemy.gif")); }
        private Brush eatingCactusEnemyBursh { get => GetBrushes(Path.Combine("Images", "enemies", "level2", "eatingCactusEnemy.gif")); }
        private Brush clamFlowerEnemyBursh { get => GetBrushes(Path.Combine("Images", "enemies", "level2", "clamFlowerEnemy.gif")); }
        private Brush threeEyesEnemyBursh { get => GetBrushes(Path.Combine("Images", "enemies", "level2", "threeEyesEnemy.gif")); }
        private Brush furryEnemyBursh { get => GetBrushes(Path.Combine("Images", "enemies", "level2", "furryEnemy.gif")); }
        private Brush cutSwordEnemyBursh { get => GetBrushes(Path.Combine("Images", "enemies", "level2", "cutSwordEnemy.gif")); }
        private Brush batEnemyBursh { get => GetBrushes(Path.Combine("Images", "enemies", "level2", "batEnemy.gif")); }
        private Brush lemonEnemyBursh { get => GetBrushes(Path.Combine("Images", "enemies", "level2", "lemonEnemy.gif")); }
        private Brush flyingEnemyBursh { get => GetBrushes(Path.Combine("Images", "enemies", "level2", "flyingEnemy.gif")); }
        private Brush zombiGiphyEnemyBursh { get => GetBrushes(Path.Combine("Images", "enemies", "level3", "zombiGiphyEnemy.gif")); }
        private Brush zombieWalkCrippleEnemyBursh { get => GetBrushes(Path.Combine("Images", "enemies", "level3", "zombieWalkCrippleEnemy.gif")); }
        private Brush zombieRunBEnemyBursh { get => GetBrushes(Path.Combine("Images", "enemies", "level3", "zombieRunBEnemy.gif")); }
        private Brush zombieAttackBEnemyBursh { get => GetBrushes(Path.Combine("Images", "enemies", "level3", "zombieAttackBEnemy.gif")); }
        private Brush zombieAttackAEnemyBrush { get => GetBrushes(Path.Combine("Images", "enemies", "level3", "zombieAttackAEnemy.gif")); }

        //Items
        private Brush BagBrush { get => GetBrushes(Path.Combine("Images", "items", "bag.png")); }
        private Brush BombBrush { get => GetBrushes(Path.Combine("Images", "items", "bomb.png")); }
        private Brush Bottle2Brush { get => GetBrushes(Path.Combine("Images", "items", "bottle2.png")); }
        private Brush CoinBrush { get => GetBrushes(Path.Combine("Images", "items", "coin.png")); }
        private Brush HeartBrush { get => GetBrushes(Path.Combine("Images", "items", "heart.png")); }
        private Brush Heart2Brush { get => GetBrushes(Path.Combine("Images", "items", "heart2.png")); }
        private Brush MoneyBrush { get => GetBrushes(Path.Combine("Images", "items", "money.png")); }
        private Brush ShieldBrush { get => GetBrushes(Path.Combine("Images", "items", "shield.png")); }
        private Brush StarBrush { get => GetBrushes(Path.Combine("Images", "items", "star.png")); }
        private Brush TearsBrush { get => GetBrushes(Path.Combine("Images", "items", "tears.png")); }
        private Brush TimeBrush { get => GetBrushes(Path.Combine("Images", "items", "time.png")); }

        private Drawing GetPigEnemy() => GetDrawing(this.pigEnemyBursh, model.PigEnemy.Area);
        private Drawing GetHippoEnemy() => GetDrawing(this.hippoEnemyBursh, model.HippoEnemy.Area);
        private Drawing GetPandaEnemy() => GetDrawing(this.pandaEnemyBursh, model.PandaEnemy.Area);
        private Drawing GetPenguinEnemy() => GetDrawing(this.penguinEnemyBursh, model.PenguinEnemy.Area);
        private Drawing GetWalkingSnailEnemy() => GetDrawing(this.walkingSnailEnemyBursh, model.WalkingSnailEnemy.Area);
        private Drawing GetEatingCactusEnemy() => GetDrawing(this.eatingCactusEnemyBursh, model.EatingCactusEnemy.Area);
        private Drawing GetClamFlowerEnemy() => GetDrawing(this.clamFlowerEnemyBursh, model.ClamFlowerEnemy.Area);
        private Drawing GetThreeEyesEnemy() => GetDrawing(this.threeEyesEnemyBursh, model.ThreeEyesEnemy.Area);
        private Drawing GetFurryEnemy() => GetDrawing(this.furryEnemyBursh, model.FurryEnemy.Area);
        private Drawing GetCutSwordEnemy() => GetDrawing(this.cutSwordEnemyBursh, model.CutSwordEnemy.Area);
        private Drawing GetBatEnemy() => GetDrawing(this.batEnemyBursh, model.BatEnemy.Area);
        private Drawing GetLemonEnemy() => GetDrawing(this.lemonEnemyBursh, model.LemonEnemy.Area);
        private Drawing GetFlyingEnemyBursh() => GetDrawing(this.flyingEnemyBursh, model.FlyingEnemy.Area);
        private Drawing GetZombiGiphyEnemy() => GetDrawing(this.zombiGiphyEnemyBursh, model.ZombiGiphyEnemy.Area);
        private Drawing GetZombieWalkCrippleEnemy() => GetDrawing(this.zombieWalkCrippleEnemyBursh, model.ZombieWalkCrippleEnemy.Area);
        private Drawing GetZombieRunBEnemy() => GetDrawing(this.zombieRunBEnemyBursh, model.ZombieRunBEnemy.Area);
        private Drawing GetZombieAttackBEnemy() => GetDrawing(this.zombieAttackBEnemyBursh, model.ZombieAttackBEnemy.Area);
        private Drawing GetZombieAttackAEnemy() => GetDrawing(this.zombieAttackAEnemyBrush, model.ZombieAttackAEnemy.Area);

        //Itmes
        //private Drawing GetBag() => GetDrawing(this.BagBrush, model.Bomb.Area);
        private Drawing GetBomb() => GetDrawing(this.BombBrush, model.Bomb.Area);
        private Drawing GetBottle2() => GetDrawing(this.Bottle2Brush, model.Bootle.Area);
        private Drawing GetCoin() => GetDrawing(this.CoinBrush, model.Coin.Area);
        private Drawing GetHeart() => GetDrawing(this.HeartBrush, model.Hearth.Area);
        //private Drawing GetHearth2() => GetDrawing(this.Heart2Brush, model.Hearth.Area);
        private Drawing GetMoney() => GetDrawing(this.MoneyBrush, model.Money.Area);
        private Drawing GetStar() => GetDrawing(this.StarBrush, model.Star.Area);
        private Drawing GetShield() => GetDrawing(this.ShieldBrush, model.Shield.Area);
        //private Drawing GetTears() => GetDrawing(this.TearsBrush, model..Area);
        //private Drawing GetTime() => GetDrawing(this.TimeBrush, model.Time.Area);

        private Dictionary<string, Drawing> Init()
        {
            Dictionary<string, Drawing> initGameDrawings = new Dictionary<string, Drawing>();

            initGameDrawings.Add("PigEnemy", GetPigEnemy());
            initGameDrawings.Add("HippoEnemy", GetHippoEnemy());
            initGameDrawings.Add("PandaEnemy", GetPandaEnemy());
            initGameDrawings.Add("PenguinEnemy", GetPenguinEnemy());
            initGameDrawings.Add("WalkingSnailEnemy", GetWalkingSnailEnemy());
            initGameDrawings.Add("EatingCactusEnemy", GetEatingCactusEnemy());
            initGameDrawings.Add("ClamFlowerEnemy", GetClamFlowerEnemy());
            initGameDrawings.Add("ThreeEyesEnemy", GetThreeEyesEnemy());
            initGameDrawings.Add("FurryEnemy", GetFurryEnemy());
            initGameDrawings.Add("CutSwordEnemy", GetCutSwordEnemy());
            initGameDrawings.Add("BatEnemy", GetBatEnemy());
            initGameDrawings.Add("LemonEnemy", GetLemonEnemy());
            initGameDrawings.Add("FlyingEnemyBursh", GetFlyingEnemyBursh());
            initGameDrawings.Add("ZombiGiphyEnemy", GetZombiGiphyEnemy());
            initGameDrawings.Add("ZombieWalkCrippleEnemy", GetZombieWalkCrippleEnemy());
            initGameDrawings.Add("ZombieRunBEnemy", GetZombieRunBEnemy());
            initGameDrawings.Add("ZombieAttackBEnemy", GetZombieAttackBEnemy());
            initGameDrawings.Add("ZombieAttackAEnemy", GetZombieAttackAEnemy());


            //Items
            initGameDrawings.Add("Bomb", GetBomb());
            initGameDrawings.Add("Bottle2", GetBottle2());
            initGameDrawings.Add("Coin", GetCoin());
            initGameDrawings.Add("Heart", GetHeart());
            initGameDrawings.Add("Money", GetMoney());
            initGameDrawings.Add("Star", GetStar());
            initGameDrawings.Add("Shield", GetShield());

            return initGameDrawings;
        }



        private Drawing GetDrawing(Brush brush, RectangleGeometry rectangleGeometry)
        {
            GeometryDrawing drawing = new GeometryDrawing(brush, null, rectangleGeometry);
            return drawing;
        }

        private ImageBrush GetBrushes(string file) => new ImageBrush(new BitmapImage(new Uri(file, UriKind.RelativeOrAbsolute)));

    }
}
