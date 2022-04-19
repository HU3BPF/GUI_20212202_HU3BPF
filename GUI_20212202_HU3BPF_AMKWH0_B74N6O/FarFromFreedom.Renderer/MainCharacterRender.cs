using FarFromFreedom.Model.Characters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FarFromFreedom.Renderer
{
    public class MainCharacterRender
    {
        public MainCharacterRender(MainCharacter character)
        {
            this.character = character;
            dobbyBack = new List<Brush>();
            dobbyFront = new List<Brush>();
            dobbyLeft = new List<Brush>();
            dobbyRight = new List<Brush>();
            string path = Path.Combine("Images", "Dobby");
            int files = Directory.GetFiles(path, "*", SearchOption.AllDirectories).Length;
            for (int i = 1; i <= 4; i++)
            {
                dobbyBack.Add(GetBrushes(Path.Combine(path, $"dobbyBack{i}.png")));
                dobbyFront.Add(GetBrushes(Path.Combine(path, $"dobbyFront{i}.png")));
                dobbyLeft.Add(GetBrushes(Path.Combine(path, $"dobbyLeft{i}.png")));
                dobbyRight.Add(GetBrushes(Path.Combine(path, $"dobbyRight{i}.png")));
            }
        }
        public List<Brush> dobbyBack { get; set; }
        public List<Brush> dobbyFront { get; set; }
        public List<Brush> dobbyLeft { get; set; }
        public List<Brush> dobbyRight { get; set; }

        private MainCharacter character;

        public int Counter => counter;

        private int counter = 0;
        public void counterUp()
        {
            if (counter >= 3 || character.DirectionHelper.DirectionChanged)
            {
                counter = 0;
                character.DirectionHelper.DefaultDirectionChange();
            }
            else
            {
                counter++;
            }
        }
        public MainCharacterRender()
        {
            dobbyBack = new List<Brush>();
            dobbyFront = new List<Brush>();
            dobbyLeft = new List<Brush>();
            dobbyRight = new List<Brush>();
            string path = Path.Combine("Images", "Dobby");
            int files = Directory.GetFiles(path, "*", SearchOption.AllDirectories).Length;
            for (int i = 1; i <= 4; i++)
            {
                dobbyBack.Add(GetBrushes(Path.Combine(path, $"dobbyBack{i}.png")));
                dobbyFront.Add(GetBrushes(Path.Combine(path, $"dobbyFront{i}.png")));
                dobbyLeft.Add(GetBrushes(Path.Combine(path, $"dobbyLeft{i}.png")));
                dobbyRight.Add(GetBrushes(Path.Combine(path, $"dobbyRight{i}.png")));
            }
            
        }

        private ImageBrush GetBrushes(string file) => new ImageBrush(new BitmapImage(new Uri(file, UriKind.RelativeOrAbsolute)));
    }
}
