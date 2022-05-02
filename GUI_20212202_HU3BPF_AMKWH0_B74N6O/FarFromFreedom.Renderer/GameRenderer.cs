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


            foreach (Enemy enemy in model.Enemies)
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

            foreach (var bullet in model.Bullets)
            {
                Brush itemBrush = GameBrushes.GetValueOrDefault("TearsBrush");
                if (itemBrush != null)
                {
                    drawingGroup.Children.Add(GetDrawing(itemBrush, bullet.Area));
                }
            }

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
            
            return drawingGroup;
        }

        private void DrawBackgroung(DrawingGroup drawingGroup)
        {
            double vystart = (1290.0 - 178.0) / 2.0;
            double hxstart = (730.0 - 175.0) / 2.0;
            //178,195 fl
            //175,175 jb
            drawingGroup.Children.Add(GetDrawing(backGroundBrushes["Level1Start_base"], new RectangleGeometry(new Rect(0, 0, 1290, 730))));


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

    }
}
