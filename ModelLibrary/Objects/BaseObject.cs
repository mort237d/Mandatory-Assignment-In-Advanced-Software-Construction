using System;
using System.Collections.Generic;
using System.Text;
using ModelLibrary.AttackObjects;
using ModelLibrary.DefenceObjects;

namespace ModelLibrary.Objects
{
    public abstract class BaseObject
    {
        private string _name;
        private int _size;
        private bool _breakable;
        private AttackBaseObject _attackBaseObject;
        private DefenceBaseObject _defenceBaseObject;
        private int _xCordinate;
        private int _yCordinate;
    }
}
