namespace ModelLibrary
{
    public class WorldObject
    {
        private string _name;
        private int _xCordinate;
        private int _yCordinate;

        public WorldObject()
        {
            Name = this.GetType().Name;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int XCordinate
        {
            get => _xCordinate;
            set => _xCordinate = value;
        }

        public int YCordinate
        {
            get => _yCordinate;
            set => _yCordinate = value;
        }
    }
}
