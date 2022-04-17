using FarFromFreedom.Model.Items;
using Newtonsoft.Json;
using System.Windows;

namespace FarFromFreedom.Model
{
    public class Bullet : GameItem
    {
        [JsonConstructor]
        public Bullet(string area, string direction) : base(area)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }

        public Bullet(Rect area, Direction direction) : base(area)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            this.direction = direction;
        }

        private Direction direction;

        public Direction Direction => direction;

    }
}
