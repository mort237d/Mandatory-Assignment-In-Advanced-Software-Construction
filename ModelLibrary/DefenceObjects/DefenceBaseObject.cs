namespace ModelLibrary.DefenceObjects
{
    public abstract class DefenceBaseObject
    {
        private string _name;
        private int _defence;
        private int _size;
        private Rarity _rarity;

        public DefenceBaseObject()
        {
            Name = this.GetType().Name;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Defence
        {
            get => _defence;
            set => _defence = value;
        }

        public int Size
        {
            get => _size;
            set => _size = value;
        }

        public Rarity Rarity1
        {
            get => _rarity;
            set => _rarity = value;
        }
    }
}
