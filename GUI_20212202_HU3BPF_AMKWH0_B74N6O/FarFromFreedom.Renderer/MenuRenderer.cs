using FarFromFreedom.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FarFromFreedom.Renderer
{
    public class MenuRenderer : IGameRenderer
    {


        private static readonly Brush _welcomePageBrush = GetBrushes(Path.Combine("Images", "MainMenu", "Start.jpg"));
        private static readonly Brush _mainMenuBrush = GetBrushes(Path.Combine("Images", "MainMenu", "MainMenu.png"));


        private Dictionary<string, Brush> backGroundBrushes = BackgroundRenderer.Init();
        private Dictionary<string, Brush> GameBrushes;
        IMenuModel model;

        
        public MenuRenderer(IMenuModel model)
        {
            this.model = model;
            GameBrushes = BurshRenderer.Init();
        }

        public DrawingGroup BuildDrawing()
        {
            DrawingGroup drawingGroup = new DrawingGroup();
            
            if (this.model.IsWelcomePage)
            {
                // Itt csak a képet töltjük be
                drawingGroup.Children.Add(this.GetDrawing(_welcomePageBrush, new RectangleGeometry(new Rect(0, 0, 1290, 730))));
                //drawingGroup.Children.Add(GetDrawing(itemBrush, item.Area));
            }
            else
            {
                // Háttér + a borderek, a modelben lesz elmentve a selected index stb 
                double xCoordinate = (1280 - this.model.ContinueWidth) / 2;

                drawingGroup.Children.Add(this.GetDrawing(_mainMenuBrush, new RectangleGeometry(new Rect(0, 0, 1290, 730))));
                drawingGroup.Children.Add(this.GetDrawing(NewGame, new RectangleGeometry(new Rect(xCoordinate-5, 170, this.model.NewGameWidth, this.model.NewGameHeight))));
                drawingGroup.Children.Add(this.GetDrawing(Continue, new RectangleGeometry(new Rect(xCoordinate+5, 250, this.model.ContinueWidth, this.model.ContinueHeight))));
                //drawingGroup.Children.Add(this.GetDrawing(Options, new RectangleGeometry(new Rect(xCoordinate+10, 340, this.model.OptionsWidth, this.model.OptionsHeight))));
                drawingGroup.Children.Add(this.GetDrawing(Stats, new RectangleGeometry(new Rect(xCoordinate+15, 350, this.model.StatsWidth, this.model.StatsHeight))));
                drawingGroup.Children.Add(this.GetDrawing(ExitGame, new RectangleGeometry(new Rect(xCoordinate+20, 430, this.model.ExitGameWidth, this.model.ExitGameHeight))));

                //drawingGroup.Children.Add(GetDrawing(itemBrush, item.Area));
            }
            return drawingGroup;
        }

        private Drawing GetDrawing(Brush brush, RectangleGeometry rectangleGeometry)
        {
            GeometryDrawing drawing = new GeometryDrawing(brush, null, rectangleGeometry);
            return drawing;
        }

        private static ImageBrush GetBrushes(string file) => new ImageBrush(new BitmapImage(new Uri(file, UriKind.RelativeOrAbsolute)));

        private Brush NewGame
        {
            get
            {
                Brush brush = GetBrushes(Path.Combine("Images", "MainMenu", "new game.png"));
                brush.Opacity = this.model.NewGameOpacity;
                return brush;
            }
        }

        private Brush Continue
        {
            get
            {
                Brush brush = GetBrushes(Path.Combine("Images", "MainMenu", "continue.png"));
                brush.Opacity = this.model.ContinueOpacity;
                return brush;
            }
        }

        private Brush Options
        {
            get
            {
                Brush brush = GetBrushes(Path.Combine("Images", "MainMenu", "options.png"));
                brush.Opacity = this.model.OptionsOpacity;
                return brush;
            }
        }

        private Brush Stats
        {
            get
            {
                Brush brush = GetBrushes(Path.Combine("Images", "MainMenu", "Stats.png"));
                brush.Opacity = this.model.StatsOpacity;
                return brush;
            }
        }

        private Brush ExitGame
        {
            get
            {
                Brush brush = GetBrushes(Path.Combine("Images", "MainMenu", "exit game.png"));
                brush.Opacity = this.model.ExitGameOpacity;
                return brush;
            }
        }


        public void GameModelChanged(IModel model)
        {
            this.model = (model as IMenuModel);
        }
    }
}
