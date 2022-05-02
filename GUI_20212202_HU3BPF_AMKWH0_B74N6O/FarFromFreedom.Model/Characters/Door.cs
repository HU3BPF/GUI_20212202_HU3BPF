using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FarFromFreedom.Model.Characters
{
    public class Door : GameItem
    {
        string description;
        int roomId;

        public Door(int level, int orientation, int roomid, Rect area) : base(area)
        {
            this.description = $"Level{level}door{orientation}";
            this.roomId = roomid;
        }

        public string Description { get => description; set => description = value; }
        public int RoomId { get => roomId; set => roomId = value; }
    }
}
