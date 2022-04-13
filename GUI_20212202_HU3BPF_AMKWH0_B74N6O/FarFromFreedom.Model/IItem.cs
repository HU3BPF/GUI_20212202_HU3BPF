using System.Windows;
using System.Windows.Media;

namespace FarFromFreedom.Model
{
    public interface IItem
    {
        RectangleGeometry Area { get; }
        string Name { get; }
        string Description { get; }

        void setArea(Rect area);
    }
}