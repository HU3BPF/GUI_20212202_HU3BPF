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
        private Dictionary<string, Brush> GameBrushes;
        private MainCharacterRender mainCharacter;
        private IGameModel model;
        private int counter;
        public GameRenderer(IGameModel model)
        {
            mainCharacter = new MainCharacterRender();
            this.model = model;
            GameBrushes = BurshRenderer.Init();
            counter = 0;
        }

        public DrawingGroup BuildDrawing()
        {
            DrawingGroup drawingGroup = new DrawingGroup();
            counter++;
            foreach (var item in model.Enemies)
            {
                Brush itemBrush = GameBrushes.GetValueOrDefault(item.Name);
                if (itemBrush != null)
                {
                    drawingGroup.Children.Add(GetDrawing(itemBrush, item.Area));
                } 
            }

            foreach (var item in model.Items)
            {
                Brush itemBrush = GameBrushes.GetValueOrDefault(item.Name);
                if (itemBrush != null)
                {
                    drawingGroup.Children.Add(GetDrawing(itemBrush, item.Area));
                }
            }
            if (counter > 5)
            {
                counter = 0;
            }
                drawingGroup.Children.Add(GetDrawing(mainCharacter.dobbyBack[counter], model.Character.Area));

            return drawingGroup;
        }


        private Drawing GetDrawing(Brush brush, RectangleGeometry rectangleGeometry)
        {
            GeometryDrawing drawing = new GeometryDrawing(brush, null, rectangleGeometry);
            return drawing;
        }

    }
}
