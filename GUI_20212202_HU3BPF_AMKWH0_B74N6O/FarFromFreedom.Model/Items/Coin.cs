namespace FarFromFreedom.Model.Items
{
    public class Coin : IItem
    {
        public Coin(string name, string description, int value)
        {
            this.name = name;
            this.description = description;
            this.value = value;
        }

        private string name;
        private string description;
        private int value;


        public string Name => name;
        public string Description => description;
        public int Value => value;
    }
}
