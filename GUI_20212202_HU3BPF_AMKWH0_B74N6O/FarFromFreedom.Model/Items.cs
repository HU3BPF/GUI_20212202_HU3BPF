namespace FarFromFreedom.Model
{
    public class Items
    {
        public Items(string name, string description, double health, double power, double speed, int coin)
        {
            this.name = name;
            this.description = description;
            this.health = health;
            this.power = power;
            this.speed = speed;
            this.coin = coin;
        }

        private string name;
        private string description;
        private double health;
        private double power;
        private double speed;
        private int coin;

        public string Name => name;

        public string Description => description;

        public double Health => health;

        public double Power => power;

        public double Speed => speed;

        public double Coin => coin;
    }
}
