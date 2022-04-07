namespace FarFromFreedom.Model.Items
{
    public class Hearth : IItem
    {
        public Hearth(string name, string description, double health)
        {
            this.name = name;
            this.description = description;
            this.health = health;
        }

        private string name;
        private string description;
        private double health;


        public string Name => name;
        public string Description => description;
        public double Health => health;
    }
}
