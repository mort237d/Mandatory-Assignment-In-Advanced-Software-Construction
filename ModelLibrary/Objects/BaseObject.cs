using ModelLibrary.AttackObjects;
using ModelLibrary.DefenceObjects;

namespace ModelLibrary.Objects
{
    public abstract class BaseObject : WorldObject
    {
        private int _size;
        private bool _breakable;

        public int Size
        {
            get => _size;
            set => _size = value;
        }

        public bool Breakable
        {
            get => _breakable;
            set => _breakable = value;
        }
    }
}
