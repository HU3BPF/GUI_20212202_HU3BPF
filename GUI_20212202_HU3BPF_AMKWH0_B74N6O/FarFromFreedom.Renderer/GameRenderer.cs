using FarFromFreedom.Model;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System;
using System.Windows.Media.Animation;

namespace FarFromFreedom.Renderer
{
    public class GameRenderer : FrameworkElement
    {
        public GameRenderer(IGameModel model)
        {
            this.model = model;
        }

        public Drawing BuildDrawing()
        {
            DrawingGroup drawingGroup = new DrawingGroup();
            drawingGroup.Children.Add(this.GetPigEnemy());
            drawingGroup.Children.Add(this.GetHippoEnemy());
            drawingGroup.Children.Add(this.GetPandaEnemy());
            drawingGroup.Children.Add(this.GetPandaEnemy());

            return drawingGroup;
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

        private Drawing GetPigEnemy() => GetDrawing(this.pigEnemyBursh, model.Enemies[1].Area);
        private Drawing GetHippoEnemy() => GetDrawing(this.hippoEnemyBursh, model.Enemies[0].Area);
        private Drawing GetPandaEnemy() => GetDrawing(this.pandaEnemyBursh, model.Enemies[2].Area);
        private Drawing GetPenguinEnemy() => GetDrawing(this.penguinEnemyBursh, model.Enemies[0].Area);
        private Drawing GetWalkingSnailEnemy() => GetDrawing(this.walkingSnailEnemyBursh, model.Enemies[0].Area);
        private Drawing GetEatingCactusEnemy() => GetDrawing(this.eatingCactusEnemyBursh, model.Enemies[0].Area);
        private Drawing GetClamFlowerEnemy() => GetDrawing(this.clamFlowerEnemyBursh,  model.Enemies[0].Area); 
        private Drawing GetThreeEyesEnemy() => GetDrawing(this.threeEyesEnemyBursh, model.Enemies[0].Area);
        private Drawing GetFurryEnemy() => GetDrawing(this.furryEnemyBursh, model.Enemies[0].Area);
        private Drawing GetCutSwordEnemy() => GetDrawing(this.cutSwordEnemyBursh, model.Enemies[0].Area);
        private Drawing GetBatEnemy() => GetDrawing(this.batEnemyBursh, model.Enemies[0].Area);
        private Drawing GetLemonEnemy() => GetDrawing(this.lemonEnemyBursh, model.Enemies[0].Area);
        private Drawing GetFlyingEnemyBursh() => GetDrawing(this.flyingEnemyBursh, model.Enemies[0].Area);
        private Drawing GetZombiGiphyEnemy() => GetDrawing(this.zombiGiphyEnemyBursh, model.Enemies[0].Area);
        private Drawing GetZombieWalkCrippleEnemyBursh() => GetDrawing(this.zombieWalkCrippleEnemyBursh, model.Enemies[0].Area);
        private Drawing GetZombieRunBEnemy() => GetDrawing(this.zombieRunBEnemyBursh, model.Enemies[0].Area);
        private Drawing GetZombieAttackBEnemy() => GetDrawing(this.zombieAttackBEnemyBursh, model.Enemies[0].Area);
        private Drawing GetZombieAttackAEnemy() => GetDrawing(this.zombieAttackAEnemyBrush, model.Enemies[0].Area);

        private Drawing GetDrawing(Brush brush, RectangleGeometry rectangleGeometry)
        {
            GeometryDrawing drawing = new GeometryDrawing(brush, null, rectangleGeometry);
            return drawing;
        }

        private ImageBrush GetBrushes(string file) => new ImageBrush(new BitmapImage(new Uri(file, UriKind.RelativeOrAbsolute)));
}
}
