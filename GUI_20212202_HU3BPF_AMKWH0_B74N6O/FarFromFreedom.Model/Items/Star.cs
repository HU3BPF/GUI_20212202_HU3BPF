namespace FarFromFreedom.Model.Items
{
    public class Star : IItem
    {
        public Star(string name, string description, double power)
        {
            this.name = name;
            this.description = description;
            this.power = power;
        }

        private string name;
        private string description;
        private double power;


        public string Name => name;
        public string Description => description;
        public double Power => power;
    }
}
