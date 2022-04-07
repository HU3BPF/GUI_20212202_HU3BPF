using System;

namespace FarFromFreedom.Repository
{
    public class SavedGame
    { 
        public string Name { get; set; }

        public int Score { get; set; }

        public DateTime date { get; set; }

        public int MapLevel { get; set; }
    }
}
