using FarFromFreedom.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FarFromFreedom.Model
{
    public class Bullet : GameItem
    {
        public Bullet(Rect area, Direction direction) : base(area)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            this.direction = direction;
        }

        private Direction direction;

        public Direction Direction => direction;

    }
}
