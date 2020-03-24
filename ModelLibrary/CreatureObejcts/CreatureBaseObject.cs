using System.Collections.Generic;
using ModelLibrary.AttackObjects;
using ModelLibrary.DefenceObjects;

namespace ModelLibrary.CreatureObejcts
{
    internal abstract class CreatureBaseObject
    {
        private string _name;
        private int _baseDamage;
        private int _baseSpeed;
        private int _size;
        private Difficulty _difficulty;
        private List<AttackBaseObject> _attackBaseObjects;
        private int _maxSizeOfAttackObject;
        private List<DefenceBaseObject> _defenceBaseObjects;
        private int _maxSizeOfDefenceObject;
    }
}
