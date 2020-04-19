using System;
using System.Collections.Generic;
using System.Text;
using ModelLibrary.AttackObjects;
using ModelLibrary.DefenceObjects;

namespace ModelLibrary.Objects
{
    public abstract class BaseObject : WorldObject
    {
        private int _size;
        private bool _breakable;
        private AttackBaseObject _attackBaseObjectBonus;
        private DefenceBaseObject _defenceBaseObjectBonus;

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

        public AttackBaseObject AttackBaseObjectBonus
        {
            get => _attackBaseObjectBonus;
            set => _attackBaseObjectBonus = value;
        }

        public DefenceBaseObject DefenceBaseObjectBonus
        {
            get => _defenceBaseObjectBonus;
            set => _defenceBaseObjectBonus = value;
        }
    }
}
