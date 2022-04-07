using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FarFromFreedom.Pages
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainMenu"/> class.
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
          

            BitmapImage bmp = new BitmapImage(new Uri(System.IO.Path.Combine("Pages", "FFF_Menu.jpg"), UriKind.RelativeOrAbsolute));
            //bmp.BeginInit();
            //bmp.StreamSource = Assembly.GetExecutingAssembly().GetManifestResourceStream("FarFromFreedom.Pages.Resources.FFF_Menu.jpg");
            //bmp.EndInit();
            ImageBrush ib = new ImageBrush(bmp);
            this.Background = ib;
        }
    }
}
