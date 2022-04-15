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
        private IGameModel model;
        public GameRenderer(IGameModel model)
        {
            this.model = model;
        }

        public DrawingGroup BuildDrawing()
        {
            GameBrushes = BurshRenderer.Init();
            DrawingGroup drawingGroup = new DrawingGroup();

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


            return drawingGroup;
        }




        private Drawing GetDrawing(Brush brush, RectangleGeometry rectangleGeometry)
        {
            GeometryDrawing drawing = new GeometryDrawing(brush, null, rectangleGeometry);
            return drawing;
        }

    }
}
