using FarFromFreedom.Model;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System;
using System.Windows.Media.Animation;
using System.Collections.Generic;
using FarFromFreedom.Model.Characters;

namespace FarFromFreedom.Renderer
{
    public class GameRenderer : FrameworkElement, IGameRenderer
    {
        private Dictionary<string, Brush> GameBrushes;
        private MainCharacterRender mainCharacterRenderer;
        private Dictionary<string, Brush> backGroundBrushes = BackgroundRenderer.Init();
        private IGameModel model;
        private int counter;
        public GameRenderer(IGameModel model)
        {
            mainCharacterRenderer = new MainCharacterRender(model.Character);
            this.model = model;
            GameBrushes = BurshRenderer.Init();
            counter = 0;
        }

        public DrawingGroup BuildDrawing()
        {
            DrawingGroup drawingGroup = new DrawingGroup();

            this.DrawBackgroung(drawingGroup);

            this.DrawEnemies(drawingGroup);

            this.DrawItems(drawingGroup);

            this.DrawTears(drawingGroup);

            this.DrawMainCharacter(drawingGroup);

            this.DrawInterface(drawingGroup);

            if (this.model.PauseModel != null)
            {
                this.DrawPauseMenu(drawingGroup);
            }
            
            return drawingGroup;
        }

        private void DrawPauseMenu(DrawingGroup drawingGroup)
        {
            double f_w = 1290;
            double f_h = 730;
            double w = 1200;
            double h = 1000;
            double x = (f_w - (w * 0.8)) / 2;
            double y = (f_h - (h * 0.8)) / 2;

            if (!this.model.PauseModel.IsDead)
            {
                drawingGroup.Children.Add(GetDrawing(backGroundBrushes["PauseMenu"], new RectangleGeometry(new Rect(x, y, w, h))));
                drawingGroup.Children.Add(this.GetDrawing(Continue,new RectangleGeometry(new Rect(5, 250, 10, 10))));
                drawingGroup.Children.Add(this.GetDrawing(SaveHighScore,new RectangleGeometry(new Rect(5, 250, 10, 10))));
            }
        }

        private void DrawInterface(DrawingGroup drawingGroup)
        {
            Brush heartBrush = GameBrushes.GetValueOrDefault("Heart");
            Brush emptyHeartBrush = GameBrushes.GetValueOrDefault("EmptyHeart");

            int hearts = (int)(this.model.Character.CurrentHealth / 10);
            int emptyhears = 10 - hearts;

            double x = 20.0;
            double y = 20.0;
            double w = 69.0*0.60;
            double h = 62.0*0.60;
            double spacing = 10.0;

            //w69 h62 
            for (int i = 1; i <= hearts; i++)
            {
                drawingGroup.Children.Add(this.GetDrawing(heartBrush, new RectangleGeometry(new Rect(x, y, w, h))));
                x += w + spacing;
            }

            for (int i = 1; i <= emptyhears; i++)
            {
                drawingGroup.Children.Add(this.GetDrawing(emptyHeartBrush, new RectangleGeometry(new Rect(x, y, w, h))));
                x += w + spacing;
            }


            string hs = this.model.Character.Highscore.ToString();
            FormattedText formattedText = new FormattedText(
              hs,
              System.Globalization.CultureInfo.CurrentCulture,
              FlowDirection.LeftToRight,
              new Typeface("Arial"),
              20,
              Brushes.Black,
              1);
            GeometryDrawing highscore = new GeometryDrawing(null, new Pen(Brushes.SandyBrown, 2), formattedText.BuildGeometry(new Point(1290 - 10 - (hs.Length*13), 20)));

            drawingGroup.Children.Add(highscore);


        }

        private void DrawMainCharacter(DrawingGroup drawingGroup)
        {
            if (model.Character is MainCharacter mainCharacter)
            {
                if (model.Character.CharacterMoved == false)
                {
                    if (model.Character.DirectionHelper.Direction == Model.Items.Direction.Down)
                    {
                        drawingGroup.Children.Add(GetDrawing(mainCharacterRenderer.dobbyFront[mainCharacterRenderer.Counter], mainCharacter.Area));
                    }
                    else if (model.Character.DirectionHelper.Direction == Model.Items.Direction.Right)
                    {
                        drawingGroup.Children.Add(GetDrawing(mainCharacterRenderer.dobbyRight[mainCharacterRenderer.Counter], mainCharacter.Area));
                    }
                    else if (model.Character.DirectionHelper.Direction == Model.Items.Direction.Left)
                    {
                        drawingGroup.Children.Add(GetDrawing(mainCharacterRenderer.dobbyLeft[mainCharacterRenderer.Counter], mainCharacter.Area));
                    }
                    else
                    {
                        drawingGroup.Children.Add(GetDrawing(mainCharacterRenderer.dobbyBack[mainCharacterRenderer.Counter], mainCharacter.Area));
                    }
                }
                else
                {
                    if (model.Character.DirectionHelper.Direction == Model.Items.Direction.Down)
                    {
                        drawingGroup.Children.Add(GetDrawing(mainCharacterRenderer.dobbyFront[mainCharacterRenderer.Counter], mainCharacter.Area));
                        mainCharacterRenderer.counterUp();
                    }
                    else if (model.Character.DirectionHelper.Direction == Model.Items.Direction.Right)
                    {
                        drawingGroup.Children.Add(GetDrawing(mainCharacterRenderer.dobbyRight[mainCharacterRenderer.Counter], mainCharacter.Area));
                        mainCharacterRenderer.counterUp();
                    }
                    else if (model.Character.DirectionHelper.Direction == Model.Items.Direction.Left)
                    {
                        drawingGroup.Children.Add(GetDrawing(mainCharacterRenderer.dobbyLeft[mainCharacterRenderer.Counter], mainCharacter.Area));
                        mainCharacterRenderer.counterUp();
                    }
                    else
                    {
                        drawingGroup.Children.Add(GetDrawing(mainCharacterRenderer.dobbyBack[mainCharacterRenderer.Counter], mainCharacter.Area));
                        mainCharacterRenderer.counterUp();
                    }
                }

            }

        }

        private void DrawTears(DrawingGroup drawingGroup)
        {
            foreach (var bullet in model.Bullets)
            {
                Brush itemBrush = GameBrushes.GetValueOrDefault("TearsBrush");
                if (itemBrush != null)
                {
                    drawingGroup.Children.Add(GetDrawing(itemBrush, bullet.Area));

                }
            }
        }

        private void DrawItems(DrawingGroup drawingGroup)
        {
            foreach (var item in model.Items)
            {
                Brush itemBrush = GameBrushes.GetValueOrDefault(item.Name);
                if (itemBrush != null)
                {
                    drawingGroup.Children.Add(GetDrawing(itemBrush, item.Area));
                }
            }
        }

        private void DrawEnemies(DrawingGroup drawingGroup)
        {
            foreach (Enemy enemy in model.Enemies)
            {
                Brush itemBrush = enemy.ImageBurshes.GetValueOrDefault(enemy.Name + enemy.Counter);
                if (itemBrush != null)
                {
                    drawingGroup.Children.Add(GetDrawing(itemBrush, enemy.Area));
                    enemy.counterUp();
                }
            }
        }

        private void DrawBackgroung(DrawingGroup drawingGroup)
        {
            int levee = this.model.Level;

            if (this.model.Level == 1 && this.model.RoomID == 1)
            {
                drawingGroup.Children.Add(GetDrawing(backGroundBrushes[$"Level{this.model.Level}Start_base"], new RectangleGeometry(new Rect(0, 0, 1290, 730))));
            }
            else
            {
                drawingGroup.Children.Add(GetDrawing(backGroundBrushes[$"Level{this.model.Level}_base"], new RectangleGeometry(new Rect(0, 0, 1290, 730))));
            }



            if (this.model.Doors.Count != 0)
            {
                foreach (Door door in this.model.Doors)
                {
                    drawingGroup.Children.Add(GetDrawing(backGroundBrushes[door.Description], door.Area));
                }
            }
            
        }

        public void GameModelChanged(IModel model) => this.model = (model as IGameModel);


        private Drawing GetDrawing(Brush brush, RectangleGeometry rectangleGeometry)
        {
            GeometryDrawing drawing = new GeometryDrawing(brush, null, rectangleGeometry);
            return drawing;
        }
        private Brush Continue
        {
            get
            {
                Brush brush = GetBrushes(Path.Combine("Images", "MainMenu", "exit game.png"));
                brush.Opacity = this.model.PauseModel.ContinueOpacity;
                return brush;
            }
        }
        private Brush SaveHighScore
        {
            get
            {
                Brush brush = GetBrushes(Path.Combine("Images", "MainMenu", "exit game.png"));
                brush.Opacity = this.model.PauseModel.SaveOpacity;
                return brush;
            }
        }

        private static ImageBrush GetBrushes(string file) => new ImageBrush(new BitmapImage(new Uri(file, UriKind.RelativeOrAbsolute)));
    }
}
