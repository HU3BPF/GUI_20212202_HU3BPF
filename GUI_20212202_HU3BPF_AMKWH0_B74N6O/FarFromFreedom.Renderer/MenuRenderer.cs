using FarFromFreedom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FarFromFreedom.Renderer
{
    public class MenuRenderer : IGameRenderer
    {

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
                //drawingGroup.Children.Add(GetDrawing(itemBrush, item.Area));
            }
            else
            {
                // Háttér + a borderek, a modelben lesz elmentve a selected index stb 
                //drawingGroup.Children.Add(GetDrawing(itemBrush, item.Area));
            }
            return drawingGroup;
        }

        public void GameModelChanged(IGameModel gameModel)
        {
            throw new NotImplementedException();
        }
    }
}
