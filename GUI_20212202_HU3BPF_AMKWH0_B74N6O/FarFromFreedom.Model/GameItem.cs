using System.Windows.Media;

namespace FarFromFreedom.Model
{
    public abstract class GameItem
    {
        public abstract Geometry Area { get; }

        public bool IsCollision(GameItem other)
        {
            return Geometry.Combine(this.Area, other.Area,
                GeometryCombineMode.Intersect, null).GetArea() > 0;
        }
    }
}
