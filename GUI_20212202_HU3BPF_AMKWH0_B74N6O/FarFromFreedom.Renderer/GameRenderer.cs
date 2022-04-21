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
        private MainCharacterRender mainCharacter;
        private IGameModel model;
        private int counter;
        public GameRenderer(IGameModel model)
        {
            mainCharacter = new MainCharacterRender(model.Character);
            this.model = model;
            GameBrushes = BurshRenderer.Init();
            counter = 0;
        }

        public DrawingGroup BuildDrawing()
        {
            DrawingGroup drawingGroup = new DrawingGroup();


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

            foreach (var item in model.bullets)
            {
                Brush itemBrush = GameBrushes.GetValueOrDefault("Bullet");
                if (itemBrush != null)
                {
                    drawingGroup.Children.Add(GetDrawing(itemBrush, item.Area));
                }
            }

            if (model.Character.CharacterMoved == false)
            {
                if (model.Character.DirectionHelper.Direction == Model.Items.Direction.Down)
                {
                    drawingGroup.Children.Add(GetDrawing(mainCharacter.dobbyFront[mainCharacter.Counter], model.Character.Area));
                }
                else if (model.Character.DirectionHelper.Direction == Model.Items.Direction.Right)
                {
                    drawingGroup.Children.Add(GetDrawing(mainCharacter.dobbyRight[mainCharacter.Counter], model.Character.Area));
                }
                else if (model.Character.DirectionHelper.Direction == Model.Items.Direction.Left)
                {
                    drawingGroup.Children.Add(GetDrawing(mainCharacter.dobbyLeft[mainCharacter.Counter], model.Character.Area));
                }
                else
                {
                    drawingGroup.Children.Add(GetDrawing(mainCharacter.dobbyBack[mainCharacter.Counter], model.Character.Area));
                }
            }
            else
            {
                if (model.Character.DirectionHelper.Direction == Model.Items.Direction.Down)
                {
                    drawingGroup.Children.Add(GetDrawing(mainCharacter.dobbyFront[mainCharacter.Counter], model.Character.Area));
                    mainCharacter.counterUp();
                }
                else if (model.Character.DirectionHelper.Direction == Model.Items.Direction.Right)
                {
                    drawingGroup.Children.Add(GetDrawing(mainCharacter.dobbyRight[mainCharacter.Counter], model.Character.Area));
                    mainCharacter.counterUp();
                }
                else if (model.Character.DirectionHelper.Direction == Model.Items.Direction.Left)
                {
                    drawingGroup.Children.Add(GetDrawing(mainCharacter.dobbyLeft[mainCharacter.Counter], model.Character.Area));
                    mainCharacter.counterUp();
                }
                else
                {
                    drawingGroup.Children.Add(GetDrawing(mainCharacter.dobbyBack[mainCharacter.Counter], model.Character.Area));
                    mainCharacter.counterUp();
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
