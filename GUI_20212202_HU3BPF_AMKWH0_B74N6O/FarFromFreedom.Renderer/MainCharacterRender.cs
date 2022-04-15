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
        public List<Brush> dobbyBack { get; set; }
        public MainCharacterRender()
        {
            dobbyBack = new List<Brush>();
            string path = Path.Combine("Images", "Dobby");
            int files = Directory.GetFiles(path, "*", SearchOption.AllDirectories).Length;
            for (int i = 1; i <= files; i++)
            {
                dobbyBack.Add(GetBrushes(Path.Combine(path, $"dobbyback{i}.png")));
            }
            
        }

        private ImageBrush GetBrushes(string file) => new ImageBrush(new BitmapImage(new Uri(file, UriKind.RelativeOrAbsolute)));
    }
}
