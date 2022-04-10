﻿using System.Windows;
using System.Windows.Media;

namespace FarFromFreedom.Model
{
    public abstract class GameItem : IMoveModel
    {
        public RectangleGeometry Area { get; }

        public Vector Speed => speed;

        private Rect area;

        private Vector speed;

        public GameItem(Rect area, Vector speed)
        {
            this.area = area;
            this.speed = speed;
            Area = new RectangleGeometry(area);
        }

        public bool IsCollision(GameItem other)
        {
            return Geometry.Combine(this.Area, other.Area,
                GeometryCombineMode.Intersect, null).GetArea() > 0;
        }

        public void MoveDown()
        {
            area.Y -= 1 * speed.Y;
            Area.Rect = area;
        }

        public void MoveUp()
        {
            area.Y += 1 * speed.Y;
            Area.Rect = area;
        }

        public void MoveLeft()
        {
            area.X -= 1 * speed.X;
            Area.Rect = area;
        }

        public void MoveRight()
        {
            area.X += 1 * speed.X;
            Area.Rect = area;
        }

        public void MoveUpRight()
        {
            area.X += 1 * speed.X;
            area.Y += 1 * speed.Y;
            Area.Rect = area;
        }

        public void MoveDownRight()
        {
            area.X += 1 * speed.X;
            area.Y -= 1 * speed.Y;
            Area.Rect = area;
        }

        public void MoveUpLeft()
        {
            area.X -= 1 * speed.X;
            area.Y += 1 * speed.Y;
            Area.Rect = area;
        }

        public void MoveDownLeft()
        {
            area.X -= 1 * speed.X;
            area.Y -= 1 * speed.Y;
            Area.Rect = area;
        }

        void SpeedUp(Vector speed)
        {
            speed.X += 0.1;
            speed.Y += 0.1;
        }
        void SpeedDown(Vector speed)
        {
            speed.X -= 0.1;
            speed.Y -= 0.1;
        }
    }
}
