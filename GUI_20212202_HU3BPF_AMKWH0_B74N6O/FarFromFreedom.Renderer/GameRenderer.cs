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

            drawingGroup.Children.Add(GetDrawing(backGroundBrushes["Level1Start"], new RectangleGeometry(new Rect(0,0,1290,730))));

            foreach (var enemy in model.Enemies)
            {
                Brush itemBrush = enemy.ImageBurshes.GetValueOrDefault(enemy.Name + enemy.Counter);
                if (itemBrush != null)
                {
                    drawingGroup.Children.Add(GetDrawing(itemBrush, enemy.Area));
                    enemy.counterUp();
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

            foreach (var bullet in model.bullets)
            {
                Brush itemBrush = GameBrushes.GetValueOrDefault("TearsBrush");
                if (itemBrush != null)
                {
                    drawingGroup.Children.Add(GetDrawing(itemBrush, bullet.Area));
                }
            }

            if (model.Character.CharacterMoved == false)
            {
                if (model.Character.DirectionHelper.Direction == Model.Items.Direction.Down)
                {
                    drawingGroup.Children.Add(GetDrawing(mainCharacterRenderer.dobbyFront[mainCharacterRenderer.Counter], model.Character.Area));
                }
                else if (model.Character.DirectionHelper.Direction == Model.Items.Direction.Right)
                {
                    drawingGroup.Children.Add(GetDrawing(mainCharacterRenderer.dobbyRight[mainCharacterRenderer.Counter], model.Character.Area));
                }
                else if (model.Character.DirectionHelper.Direction == Model.Items.Direction.Left)
                {
                    drawingGroup.Children.Add(GetDrawing(mainCharacterRenderer.dobbyLeft[mainCharacterRenderer.Counter], model.Character.Area));
                }
                else
                {
                    drawingGroup.Children.Add(GetDrawing(mainCharacterRenderer.dobbyBack[mainCharacterRenderer.Counter], model.Character.Area));
                }
            }
            else
            {
                if (model.Character.DirectionHelper.Direction == Model.Items.Direction.Down)
                {
                    drawingGroup.Children.Add(GetDrawing(mainCharacterRenderer.dobbyFront[mainCharacterRenderer.Counter], model.Character.Area));
                    mainCharacterRenderer.counterUp();
                }
                else if (model.Character.DirectionHelper.Direction == Model.Items.Direction.Right)
                {
                    drawingGroup.Children.Add(GetDrawing(mainCharacterRenderer.dobbyRight[mainCharacterRenderer.Counter], model.Character.Area));
                    mainCharacterRenderer.counterUp();
                }
                else if (model.Character.DirectionHelper.Direction == Model.Items.Direction.Left)
                {
                    drawingGroup.Children.Add(GetDrawing(mainCharacterRenderer.dobbyLeft[mainCharacterRenderer.Counter], model.Character.Area));
                    mainCharacterRenderer.counterUp();
                }
                else
                {
                    drawingGroup.Children.Add(GetDrawing(mainCharacterRenderer.dobbyBack[mainCharacterRenderer.Counter], model.Character.Area));
                    mainCharacterRenderer.counterUp();
                }
            }
            return drawingGroup;
        }

        public void GameModelChanged(IGameModel gameModel) => this.model = gameModel;


        private Drawing GetDrawing(Brush brush, RectangleGeometry rectangleGeometry)
        {
            GeometryDrawing drawing = new GeometryDrawing(brush, null, rectangleGeometry);
            return drawing;
        }

    }
}
