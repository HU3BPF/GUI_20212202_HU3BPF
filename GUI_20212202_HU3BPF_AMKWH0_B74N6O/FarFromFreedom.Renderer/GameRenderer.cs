using FarFromFreedom.Model;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System;

namespace FarFromFreedom.Renderer
{
    public class GameRenderer : FrameworkElement
    {
        public GameRenderer(IGameModel model)
        {
            this.model = model;
        }

        private IGameModel model;

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

        private Drawing GetPigEnemy() => GetDrawing(this.pigEnemyBursh, new RectangleGeometry(model.Enemies[1].Area.GetRenderBounds(new Pen())));
        private Drawing GetHippoEnemy() => GetDrawing(this.hippoEnemyBursh, new RectangleGeometry(model.Enemies[1].Area.GetRenderBounds(new Pen())));
        private Drawing GetPandaEnemy() => GetDrawing(this.pandaEnemyBursh, new RectangleGeometry(model.Enemies[1].Area.GetRenderBounds(new Pen())));
        private Drawing GetPenguinEnemy() => GetDrawing(this.penguinEnemyBursh, new RectangleGeometry(model.Enemies[1].Area.GetRenderBounds(new Pen())));
        private Drawing GetWalkingSnailEnemy() => GetDrawing(this.walkingSnailEnemyBursh, new RectangleGeometry(model.Enemies[1].Area.GetRenderBounds(new Pen())));
        private Drawing GetEatingCactusEnemy() => GetDrawing(this.eatingCactusEnemyBursh, new RectangleGeometry(model.Enemies[1].Area.GetRenderBounds(new Pen())));
        private Drawing GetClamFlowerEnemy() => GetDrawing(this.clamFlowerEnemyBursh, new RectangleGeometry(model.Enemies[1].Area.GetRenderBounds(new Pen())));
        private Drawing GetThreeEyesEnemy() => GetDrawing(this.threeEyesEnemyBursh, new RectangleGeometry(model.Enemies[1].Area.GetRenderBounds(new Pen())));
        private Drawing GetFurryEnemy() => GetDrawing(this.furryEnemyBursh, new RectangleGeometry(model.Enemies[1].Area.GetRenderBounds(new Pen())));
        private Drawing GetCutSwordEnemy() => GetDrawing(this.cutSwordEnemyBursh, new RectangleGeometry(model.Enemies[1].Area.GetRenderBounds(new Pen())));
        private Drawing GetBatEnemy() => GetDrawing(this.batEnemyBursh, new RectangleGeometry(model.Enemies[1].Area.GetRenderBounds(new Pen())));
        private Drawing GetLemonEnemy() => GetDrawing(this.lemonEnemyBursh, new RectangleGeometry(model.Enemies[1].Area.GetRenderBounds(new Pen())));
        private Drawing GetFlyingEnemyBursh() => GetDrawing(this.flyingEnemyBursh, new RectangleGeometry(model.Enemies[1].Area.GetRenderBounds(new Pen())));
        private Drawing GetZombiGiphyEnemy() => GetDrawing(this.zombiGiphyEnemyBursh, new RectangleGeometry(model.Enemies[1].Area.GetRenderBounds(new Pen())));
        private Drawing GetZombieWalkCrippleEnemyBursh() => GetDrawing(this.zombieWalkCrippleEnemyBursh, new RectangleGeometry(model.Enemies[1].Area.GetRenderBounds(new Pen())));
        private Drawing GetZombieRunBEnemy() => GetDrawing(this.zombieRunBEnemyBursh, new RectangleGeometry(model.Enemies[1].Area.GetRenderBounds(new Pen())));
        private Drawing GetZombieAttackBEnemy() => GetDrawing(this.zombieAttackBEnemyBursh, new RectangleGeometry(model.Enemies[1].Area.GetRenderBounds(new Pen())));
        private Drawing GetZombieAttackAEnemy() => GetDrawing(this.zombieAttackAEnemyBrush, new RectangleGeometry(model.Enemies[1].Area.GetRenderBounds(new Pen())));

        private Drawing GetDrawing(Brush brush, RectangleGeometry rectangleGeometry)
        {
            GeometryDrawing drawing = new GeometryDrawing(brush, null, rectangleGeometry);
            return drawing;
        }

        private ImageBrush GetBrushes(string file) => new ImageBrush(new BitmapImage(new Uri(file, UriKind.RelativeOrAbsolute)));
}
}
