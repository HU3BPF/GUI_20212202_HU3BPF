﻿using System.Windows;
using System.Windows.Media;

namespace FarFromFreedom.Model.Items
{
    public class Coin : IItem
    {
        public Coin(Rect area)
        {
            this.area = area;
        }

        public string Name => "Coin";
        public string Description => "Coin";
        public int Value => 1;

        public RectangleGeometry Area => new RectangleGeometry(area);

        private Rect area;

        public void setArea(Rect area)
        {
            this.area = area;
        }
    }
}
